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
    public class HomeSlideController : Controller
    {
        // GET: Admin/HomeSlide
        // CRUD Home Slider

        EduHomeContex db = new EduHomeContex();

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<HomeSlide> homeSlides = db.HomeSlides.ToList();
            return View(homeSlides);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HomeSlide homeSlide)
        {
            if (ModelState.IsValid)
            {
                if (homeSlide.ImageFile==null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    return View(homeSlide);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + homeSlide.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    homeSlide.ImageFile.SaveAs(imagePath);
                    homeSlide.Image = imageName;
                }
                db.HomeSlides.Add(homeSlide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeSlide);
        }

        public ActionResult Update(int id)
        {
            HomeSlide homeSlide = db.HomeSlides.Find(id);
            if (homeSlide==null)
            {
                return HttpNotFound();
            }
            return View(homeSlide);
        }

        [HttpPost]
        public ActionResult Update(HomeSlide homeSlide)
        {
            HomeSlide HomeSlide = db.HomeSlides.Find(homeSlide.Id);
            if (ModelState.IsValid)
            {

                if (homeSlide.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + homeSlide.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), HomeSlide.Image);
                    System.IO.File.Delete(oldImagePath);

                    homeSlide.ImageFile.SaveAs(imagePath);
                    HomeSlide.Image = imageName;
                }

                HomeSlide.Title = homeSlide.Title;
                HomeSlide.Content = homeSlide.Content;

                db.Entry(HomeSlide).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(HomeSlide);
        }


        public ActionResult Delete(int id)
        {
            HomeSlide homeSlide = db.HomeSlides.Find(id);
            if (homeSlide == null)
            {
                return HttpNotFound();
            }
            db.HomeSlides.Remove(homeSlide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}