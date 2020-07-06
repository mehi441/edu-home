using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class SocialController : Controller
    {
        // GET: Admin/Social

        // CRUD Teachers' Socials
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Social> socials = db.Socials.Include("Teacher").ToList();
            return View(socials);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            ViewBag.Teachers = db.Teachers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Social social)
        {
            if (ModelState.IsValid)
            {
                db.Socials.Add(social);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teachers = db.Teachers.ToList();
            return View();
        }

        public ActionResult Update(int id)
        {
            Social social = db.Socials.Find(id);
            if (social==null)
            {
                return HttpNotFound();
            }
            ViewBag.Teachers = db.Teachers.ToList();
            return View(social);
        }


        [HttpPost]
        public ActionResult Update(Social social)
        {
            if (social.TeacherId < 1)
            {
                ModelState.AddModelError("", "teacher is required");
                ViewBag.Teachers = db.Teachers.ToList();
                return View(social);
            }
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teachers = db.Teachers.ToList();
            return View(social);
        }


        public ActionResult Delete(int id)
        {
            Social social = db.Socials.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            db.Socials.Remove(social);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}