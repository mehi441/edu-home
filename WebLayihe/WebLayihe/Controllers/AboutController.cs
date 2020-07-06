using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;
using WebLayihe.ViewModels;

namespace WebLayihe.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        // ABOUT PAGE
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            VmAbout vmAbout = new VmAbout();
            vmAbout.Header = db.Headers.FirstOrDefault(h=> h.Page=="About");
            vmAbout.Teachers = db.Teachers.OrderBy(t => t.Id).Take(4).Include("Socials").Include("Occupation").ToList();

            VmNotice vmNotice = new VmNotice();
            vmNotice.About = db.Abouts.FirstOrDefault();
            vmNotice.Notices = db.Notices.ToList();

            vmAbout.VmNotice = vmNotice;



            VmAboutSlider vmAboutSlider = new VmAboutSlider();
            vmAboutSlider.AboutSlide = db.AboutSlides.Include("Occupation").FirstOrDefault();
            vmAboutSlider.Setting = db.Settings.FirstOrDefault();

            vmAbout.VmAboutSlider = vmAboutSlider;

            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }

            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmAbout);
        }
    }
}