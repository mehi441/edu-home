using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;
using WebLayihe.ViewModels;

namespace WebLayihe.Controllers
{
    public class EventDetailController : Controller
    {
        // GET: EventDetail
        // EVENT DETAILS 
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index(int id)
        {
            VmEventDetail vmEventDetail = new VmEventDetail();
            vmEventDetail.Header = db.Headers.FirstOrDefault(h=> h.Page== "Event Details");
            vmEventDetail.Setting = db.Settings.FirstOrDefault();
            vmEventDetail.EventCatagories = db.EventCatagories.ToList();
            vmEventDetail.Blogs = db.Blogs.OrderByDescending(b => b.Id).Take(3).ToList();
            if (db.Events.Find(id)==null)
            {
                return RedirectToAction("Index","Event");
            }
            vmEventDetail.Event = db.Events.Find(id);



            vmEventDetail.SpeakerEvents = db.SpeakerEvents.Include("Speaker").Where(s => s.EventId == id).ToList();

            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmEventDetail);
        }
    }
}