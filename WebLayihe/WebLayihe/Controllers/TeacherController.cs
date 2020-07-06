using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.ViewModels;

namespace WebLayihe.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            VmTeacher vmTeacher = new VmTeacher();
            vmTeacher.Teachers = db.Teachers.Include("Occupation").Include("Socials").ToList();


            vmTeacher.Header = db.Headers.FirstOrDefault(h => h.Page == "Teacher");


            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmTeacher);
        }
    }
}