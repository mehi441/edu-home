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
    public class OccupationController : Controller
    {
        // GET: Admin/Occupation

        EduHomeContex db = new EduHomeContex();

        // CRUD occupation

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Occupation> occupations = db.Occupations.ToList();
            return View(occupations);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Occupations.Add(occupation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occupation);
        }

        public ActionResult Update(int id)
        {
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }

            return View(occupation);
        }

        [HttpPost]
        public ActionResult Update(Occupation occupation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occupation).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index");
            }

            return View(occupation);
        }

        public ActionResult Delete(int id)
        {
            Occupation occupation = db.Occupations.Find(id);
            if (occupation == null)
            {
                return HttpNotFound();
            }
            db.Occupations.Remove(occupation);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}