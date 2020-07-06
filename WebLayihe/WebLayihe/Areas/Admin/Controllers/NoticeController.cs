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
    public class NoticeController : Controller
    {
        // GET: Admin/Notice
        EduHomeContex db = new EduHomeContex();

        // Notice CRUD 

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Notice> notices = db.Notices.ToList();
            return View(notices);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Notices.Add(notice);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(notice);
        }

        public ActionResult Update(int id)
        {
            Notice notice = db.Notices.Find(id);

            if (notice==null)
            {
                return HttpNotFound();
            }

            return View(notice);
        }

        [HttpPost]
        public ActionResult Update(Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(notice);
        }

        public ActionResult Delete(int id)
        {
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }

            db.Notices.Remove(notice);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}