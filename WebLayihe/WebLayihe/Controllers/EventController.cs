using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.ViewModels;

namespace WebLayihe.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        // EVENTS PAGE
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            VmEvent vmEvent = new VmEvent();

            vmEvent.Header = db.Headers.FirstOrDefault(h => h.Page == "Event");
            vmEvent.Events = db.Events.OrderBy(e=>e.Id).Take(6).Include("Catagory").ToList();
            vmEvent.EventCatagories = db.EventCatagories.ToList();
            vmEvent.Setting = db.Settings.FirstOrDefault();
            vmEvent.Blogs = db.Blogs.OrderByDescending(b=>b.Id).Take(3).ToList();
            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmEvent);
        }
    }
}