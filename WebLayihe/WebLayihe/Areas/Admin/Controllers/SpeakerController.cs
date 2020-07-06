using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class SpeakerController : Controller
    {
        // GET: Admin/Speaker
        // CRUD Speakers

        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Speaker> speakers = db.Speakers.Include("Occupation").ToList();
            return View(speakers);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            ViewBag.Occupations = db.Occupations.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(Speaker speaker)
        {

            if (speaker.OccupationId < 1)
            {
                ModelState.AddModelError("", "occupation is required");
                ViewBag.Occupations = db.Occupations.ToList();
                return View(speaker);
            }

            if (ModelState.IsValid)
            {

                if (speaker.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    ViewBag.Occupations = db.Occupations.ToList();
                    return View(speaker);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    speaker.ImageFile.SaveAs(imagePath);
                    speaker.Image = imageName;
                }

                db.Speakers.Add(speaker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Occupations = db.Occupations.ToList();
            return View();
        }

        public ActionResult Update(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            if (speaker==null)
            {
                return HttpNotFound();
            }
            ViewBag.Occupations = db.Occupations.ToList();
            return View(speaker);
        }

        [HttpPost]

        public ActionResult Update(Speaker speaker)
        {
            Speaker Speaker = db.Speakers.Find(speaker.Id);

            if (speaker.OccupationId < 1)
            {
                ModelState.AddModelError("", "occupation is required");
                ViewBag.Occupations = db.Occupations.ToList();
                return View(Speaker);
            }
            if (ModelState.IsValid)
            {
                if (speaker.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Speaker.Image);
                    System.IO.File.Delete(oldImagePath);

                    speaker.ImageFile.SaveAs(imagePath);
                    Speaker.Image = imageName;
                }

                Speaker.Fullname = speaker.Fullname;
                Speaker.OccupationId = speaker.OccupationId;

                db.Entry(Speaker).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            ViewBag.Occupations = db.Occupations.ToList();
            return View(Speaker);
        }


        public ActionResult Delete(int id)
        {
            Speaker speaker = db.Speakers.Find(id);
            if (speaker == null)
            {
                return HttpNotFound();
            }
            db.Speakers.Remove(speaker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}