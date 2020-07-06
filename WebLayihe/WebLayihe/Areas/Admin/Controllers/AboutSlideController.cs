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
    public class AboutSlideController : Controller
    {
        // GET: Admin/AboutSlide

        // CRUD About Slider

        EduHomeContex db = new EduHomeContex();

        public ActionResult Index()
        {

            if (Session["Admin"] != null)
            {
                   List<AboutSlide> aboutSlides = db.AboutSlides.Include("Occupation").ToList();
                 return View(aboutSlides);
            }
            return RedirectToAction("Login", "RegisterAdmin");

            
        }


        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
                
            ViewBag.Occupations = db.Occupations.ToList();
            return View();
            }
            return RedirectToAction("Login", "RegisterAdmin");

            
        }

        [HttpPost]
        public ActionResult Create(AboutSlide aboutSlide)
        {

            if (aboutSlide.OccupationId<1)
            {
                ModelState.AddModelError("", "occupation is required");
                ViewBag.Occupations = db.Occupations.ToList();
                return View(aboutSlide);
            }
            if (ModelState.IsValid)
            {
                if (aboutSlide.ImageFile==null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    ViewBag.Occupations = db.Occupations.ToList();
                    return View(aboutSlide);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + aboutSlide.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    aboutSlide.ImageFile.SaveAs(imagePath);
                    aboutSlide.Image = imageName;
                }

                db.AboutSlides.Add(aboutSlide);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Occupations = db.Occupations.ToList();
            return View();
        }

        public ActionResult Update(int id)
        {

            if (Session["Admin"] != null)
            {
         AboutSlide aboutSlide = db.AboutSlides.Find(id);
                    if (aboutSlide==null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.Occupations = db.Occupations.ToList();
                    return View(aboutSlide);
            }
            return RedirectToAction("Login", "RegisterAdmin");


           
        }

        [HttpPost]
        public ActionResult Update(AboutSlide aboutSlide)
        {
            AboutSlide AboutSlide = db.AboutSlides.Find(aboutSlide.Id);

            if (aboutSlide.OccupationId < 1)
            {
                ModelState.AddModelError("", "occupation is required");
                ViewBag.Occupations = db.Occupations.ToList();
                return View(AboutSlide);
            }
            if (ModelState.IsValid)
            {
                if (aboutSlide.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + aboutSlide.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), AboutSlide.Image);
                    System.IO.File.Delete(oldImagePath);

                    aboutSlide.ImageFile.SaveAs(imagePath);
                    AboutSlide.Image = imageName;
                }

                AboutSlide.Fullname = aboutSlide.Fullname;
                AboutSlide.Content = aboutSlide.Content;
                AboutSlide.OccupationId = aboutSlide.OccupationId;

                db.Entry(AboutSlide).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Occupations = db.Occupations.ToList();
            return View(AboutSlide);
        }


        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                AboutSlide aboutSlide = db.AboutSlides.Find(id);
                if (aboutSlide== null)
                {
                    return HttpNotFound();
                }
                db.AboutSlides.Remove(aboutSlide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

    }
}