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
    public class CourseCatagoryController : Controller
    {
        // GET: Admin/CourseCatagory

        // CRUD Course catagories

        EduHomeContex db = new EduHomeContex();

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<CourseCatagory> courseCatagories = db.CourseCatagories.ToList();
            return View(courseCatagories);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseCatagory courseCatagory)
        {

            if (ModelState.IsValid)
            {
                db.CourseCatagories.Add(courseCatagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseCatagory);
        }

        public ActionResult Update(int id)
        {
            CourseCatagory courseCatagory = db.CourseCatagories.Find(id);
            if (courseCatagory==null)
            {
                return HttpNotFound();
            }
            return View(courseCatagory);
        }

        [HttpPost]
        public ActionResult Update(CourseCatagory courseCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseCatagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseCatagory);
        }

        public ActionResult Delete(int id)
        {
            CourseCatagory courseCatagory = db.CourseCatagories.Find(id);
            if (courseCatagory==null)
            {
                return HttpNotFound();
            }
            db.CourseCatagories.Remove(courseCatagory);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}