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
    public class EventCatagoryController : Controller
    {
        // GET: Admin/EventCatagory
        // CRUD EVENT catagory

        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<EventCatagory> eventCatagories = db.EventCatagories.ToList();
            return View(eventCatagories);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventCatagory eventCatagory)
        {

            if (ModelState.IsValid)
            {
                db.EventCatagories.Add(eventCatagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventCatagory);
        }

        public ActionResult Update(int id)
        {
            EventCatagory eventCatagory = db.EventCatagories.Find(id);
            if (eventCatagory == null)
            {
                return HttpNotFound();
            }
            return View(eventCatagory);
        }

        [HttpPost]
        public ActionResult Update(EventCatagory eventCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventCatagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventCatagory);
        }

        public ActionResult Delete(int id)
        {
            EventCatagory eventCatagory = db.EventCatagories.Find(id);
            if (eventCatagory == null)
            {
                return HttpNotFound();
            }
            db.EventCatagories.Remove(eventCatagory);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}