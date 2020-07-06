using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.ViewModels;

namespace WebLayihe.Controllers
{
    public class TeacherDetailController : Controller
    {
        // GET: TeacherDetail
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index(int id)
        {
            VmTeacherDetails vmTeacherDetails = new VmTeacherDetails();
            vmTeacherDetails.Header = db.Headers.FirstOrDefault(h => h.Page == "Teacher Details");
            if (db.Teachers.Find(id)==null)
            {
                return RedirectToAction("Index","Teacher");
            }
            vmTeacherDetails.Teacher = db.Teachers.Find(id);
            vmTeacherDetails.Occupation = db.Occupations.FirstOrDefault(o=> o.Id==vmTeacherDetails.Teacher.OccupationId);
            vmTeacherDetails.Socials = db.Socials.Where(s=> s.TeacherId==id).ToList();
            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmTeacherDetails);
        }
    }
}