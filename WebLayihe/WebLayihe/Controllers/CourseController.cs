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
    public class CourseController : Controller
    {
        // GET: Course
        // Course PAGE
        EduHomeContex db = new EduHomeContex();

        public ActionResult Index(string search)
        {
            VmCourse vmCourse = new VmCourse();
            vmCourse.Courses = db.Courses.Where(s => search == null? true:( 
                                                     s.Title.Contains(search) || s.Explanation.Contains(search) ||
                                                     s.Content.Contains(search) || s.Language.Contains(search)
                                                    )).Include("Catagory").ToList();

            vmCourse.Header = db.Headers.FirstOrDefault(h => h.Page == "Course");

            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmCourse);
        }









    }
}