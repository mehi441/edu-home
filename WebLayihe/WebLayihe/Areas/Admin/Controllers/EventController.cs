using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
        // GET: Admin/Event
        // CRUD event
        EduHomeContex db = new EduHomeContex();

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Event> events = db.Events.Include("Catagory").ToList();
            ViewBag.SpeakerEvents = db.SpeakerEvents.Include("Speaker").ToList();
            return View(events);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            ViewBag.Catagories = db.EventCatagories.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Event event1)
        {
            if (event1.CatagoryId < 1)
            {
                ModelState.AddModelError("", "catagory is required");
                ViewBag.Catagories = db.EventCatagories.ToList();
                ViewBag.Speakers = db.Speakers.ToList();
                return View(event1);
            }
            for (int i = 0; i < event1.SpeakerId.Length; i++)
            {
                if (event1.SpeakerId[i] < 1)
                {
                    ModelState.AddModelError("", "speaker is required");
                    ViewBag.Catagories = db.EventCatagories.ToList();
                    ViewBag.Speakers = db.Speakers.ToList();
                    return View(event1);
                }
            }

            if (ModelState.IsValid)
            {
                if (event1.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    ViewBag.Catagories = db.EventCatagories.ToList();
                    ViewBag.Speakers = db.Speakers.ToList();
                    return View(event1);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + event1.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    event1.ImageFile.SaveAs(imagePath);
                    event1.Image = imageName;
                }
                db.Events.Add(event1);
                db.SaveChanges();

                for (int i = 0; i < event1.SpeakerId.Length; i++)
                {
                    SpeakerEvent speakerEvent = new SpeakerEvent();
                    speakerEvent.EventId = event1.Id;
                    speakerEvent.SpeakerId = event1.SpeakerId[i];

                    db.SpeakerEvents.Add(speakerEvent);
                    db.SaveChanges();

                }
                return RedirectToAction("Index");

            }


            ViewBag.Catagories = db.EventCatagories.ToList();
            ViewBag.Speakers = db.Speakers.ToList();
            return View(event1);
        }


         // AJAX ucun metod
        public ActionResult GetSpeaker()
        {

            string options = "";
            foreach (Speaker item in db.Speakers)
            {
                options += "<option value='"+item.Id+"' >"+item.Fullname+"</option>";
            }

            string hederChoose = "<div class='form - group'><div class='col - md - 10'><label>Speaker</label><select class='form - control' name='SpeakerId'><option value='0'>Choose</option>";
            string footerChoose = "</select></div></div>";

            return Content(hederChoose+ options+footerChoose);
        }
        // DELETE
        public ActionResult Delete(int id)
        {
            Event event1 = db.Events.Find(id);
            if (event1==null)
            {
                return HttpNotFound();
            }
            db.Events.Remove(event1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        


    }
}