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
    public class SettingSocialController : Controller
    {
        // GET: Admin/SettingSocial
        // CRUD setting social
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<SettingSocial> settingSocials = db.SettingSocials.Include("Setting").ToList();
            return View(settingSocials);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            ViewBag.Settings = db.Settings.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SettingSocial settingSocial)
        {
            if (settingSocial.SettingId < 1)
            {
                ModelState.AddModelError("", "setting is required");
                ViewBag.Settings = db.Settings.ToList();
                return View(settingSocial);
            }
            if (ModelState.IsValid)
            {
                db.SettingSocials.Add(settingSocial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Settings = db.Settings.ToList();
            return View(settingSocial);
        }

        public ActionResult Update(int id)
        {
            SettingSocial settingSocial = db.SettingSocials.Find(id);
            if (settingSocial==null)
            {
                return HttpNotFound();
            }
            ViewBag.Settings = db.Settings.ToList();
            return View(settingSocial);
        }

        [HttpPost]
        public ActionResult Update(SettingSocial settingSocial)
        {
            SettingSocial SettingSocial = db.SettingSocials.Find(settingSocial.Id);
            if (settingSocial.SettingId < 1)
            {
                ModelState.AddModelError("", "setting is required");
                ViewBag.Settings = db.Settings.ToList();
                return View(settingSocial);
            }
            if (ModelState.IsValid)
            {

                SettingSocial.Name = settingSocial.Name;
                SettingSocial.Icon = settingSocial.Icon;
                SettingSocial.Link = settingSocial.Link;
                SettingSocial.SettingId = settingSocial.SettingId;

                db.Entry(SettingSocial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Settings = db.Settings.ToList();
            return View(SettingSocial);
        }

        public ActionResult Delete(int id)
        {
            SettingSocial settingSocial = db.SettingSocials.Find(id);
            if (settingSocial==null)
            {
                return  HttpNotFound();
            }
            db.SettingSocials.Remove(settingSocial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}