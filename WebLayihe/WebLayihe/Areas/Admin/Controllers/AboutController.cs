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
    public class AboutController : Controller
    {
        // GET: Admin/About
        EduHomeContex db = new EduHomeContex();

        // CRUD About
        public ActionResult Index()
        {

            if (Session["Admin"]!=null)
            {
                List<About> abouts = db.Abouts.ToList();
                return View(abouts);
            }
            return RedirectToAction("Login", "RegisterAdmin");
        
        }

        public ActionResult Create()
        {
            if (Session["Admin"]!=null)
            {
                return View();
            }
            return RedirectToAction("Login", "RegisterAdmin");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                if (about.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    return View(about);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    about.ImageFile.SaveAs(imagePath);
                    about.Image = imageName;
                }

                if (about.VideoBgImageFile==null)
                {
                    ModelState.AddModelError("","background image is requred");
                    return View(about);
                }
                else
                {
                    string videoBgImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.VideoBgImageFile.FileName;
                    string videoBgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), videoBgImageName);

                    about.VideoBgImageFile.SaveAs(videoBgImagePath);
                    about.VideoBgImage = videoBgImageName;
                }

                db.Abouts.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about);
        }


        public ActionResult Update( int id)
        {
            if (Session["Admin"] != null)
            {
                About about = db.Abouts.Find(id);
                if (about == null)
                {
                    return HttpNotFound();
                }
                return View(about);
            }
            return RedirectToAction("Login", "RegisterAdmin");


        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(About about)
        {
            About About = db.Abouts.Find(about.Id);

            if (ModelState.IsValid)
            {
                if (about.ImageFile!=null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), About.Image);
                    System.IO.File.Delete(oldImagePath);

                    about.ImageFile.SaveAs(imagePath);
                    About.Image = imageName;
                }

                if (about.VideoBgImageFile!=null)
                {
                    string videoBgImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.VideoBgImageFile.FileName;
                    string videoBgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), videoBgImageName);

                    string oldVideoBgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), About.VideoBgImage);
                    System.IO.File.Delete(oldVideoBgImagePath);

                    about.VideoBgImageFile.SaveAs(videoBgImagePath);
                    About.VideoBgImage = videoBgImageName;
                }

                About.Content = about.Content;
                About.VideoTitle = about.VideoTitle;
                About.VideoLink = about.VideoLink;
                About.NoticeTitle = about.NoticeTitle;

                db.Entry(About).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(About);
        }

        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
                About about = db.Abouts.Find(id);
                if (about == null)
                {
                    return HttpNotFound();
                }
                db.Abouts.Remove(about);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "RegisterAdmin");


            
        }

        public ActionResult Details(int id)
        {
            if (Session["Admin"] != null)
            {
                About about = db.Abouts.Find(id);
                if (about == null)
                {
                    return HttpNotFound();
                }
                return View(about);
            }
            return RedirectToAction("Login", "RegisterAdmin");
        }

    }
}