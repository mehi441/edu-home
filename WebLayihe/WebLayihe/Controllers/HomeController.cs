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
    public class HomeController : Controller
    {

        // HOME Page
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            VmHome vmHome = new VmHome();
            vmHome.HomeSlides = db.HomeSlides.ToList();
            vmHome.Teachers = db.Teachers.OrderBy(t => t.Id).Take(4).Include("Occupation").Include("Socials").ToList();
            vmHome.Courses = db.Courses.OrderByDescending(c => c.Id).Take(3).ToList();

            VmNotice vmNotice = new VmNotice();
            vmNotice.About = db.Abouts.FirstOrDefault();
            vmNotice.Notices = db.Notices.ToList();
            vmHome.VmNotice = vmNotice;


            vmHome.Events = db.Events.OrderByDescending(e => e.Id).Take(4).ToList();
            vmHome.Blogs = db.Blogs.OrderByDescending(b => b.Id).Take(3).ToList();

            VmAboutSlider vmAboutSlider = new VmAboutSlider();
            vmAboutSlider.Setting = db.Settings.FirstOrDefault();
            vmAboutSlider.AboutSlide = db.AboutSlides.Include("Occupation").FirstOrDefault();
            vmHome.VmAboutSlider = vmAboutSlider;

            if (Session["User"]!=null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmHome);
        }
    }
}