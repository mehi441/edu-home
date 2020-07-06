using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class SubscribeController : Controller
    {
        // GET: Admin/Subscribe

        //READ Subscribe
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Subscribe> subscribes = db.Subscribes.ToList();
            return View(subscribes);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }


        public ActionResult Delete(int id)
        {
            Subscribe subscribe = db.Subscribes.Find(id);
            if (subscribe==null)
            {
                return HttpNotFound();
            }
            db.Subscribes.Remove(subscribe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}