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
    public class CourseDetailController : Controller
    {
        // GET: CourseDetail
        // COURSE DETAILS PAGE VITH COURSE ID
        EduHomeContex db = new EduHomeContex();

        public ActionResult Index(int id)
        {

            VmCourseDetail vmCourseDetail = new VmCourseDetail();

            vmCourseDetail.Header = db.Headers.FirstOrDefault(h => h.Page == "Course Details");
            vmCourseDetail.Course = db.Courses.Find(id);
            vmCourseDetail.Setting = db.Settings.FirstOrDefault();
            vmCourseDetail.CourseCatagories = db.CourseCatagories.ToList();
            vmCourseDetail.Blogs = db.Blogs.OrderByDescending(b => b.Id).Take(3).ToList();
            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmCourseDetail);
        }
    }
}