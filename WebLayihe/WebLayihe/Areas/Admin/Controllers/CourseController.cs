using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        // GET: Admin/Course

        // CRUD Course

        EduHomeContex db = new EduHomeContex();

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Course> courses = db.Courses.Include("Catagory").ToList();
            return View(courses);
            }
            return RedirectToAction("Login", "RegisterAdmin");




        }

        public ActionResult Create()
        {
            ViewBag.Catagories = db.CourseCatagories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Course course)
        {

            if (course.CatagoryId < 1)
            {
                ModelState.AddModelError("", "catagory is required");
                ViewBag.Catagories = db.CourseCatagories.ToList();
                return View(course);
            }

            if (ModelState.IsValid)
            {
                if (course.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    ViewBag.Catagories = db.CourseCatagories.ToList();
                    return View(course);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    course.ImageFile.SaveAs(imagePath);
                    course.Image = imageName;
                }
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Catagories = db.CourseCatagories.ToList();
            return View();
        }

        public ActionResult Update(int id)
        {
            Course course = db.Courses.Find(id);
            if (course== null)
            {
                return HttpNotFound();
            }
            ViewBag.Catagories = db.CourseCatagories.ToList();
            return View(course);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Course course)
        {
            Course Course = db.Courses.Find(course.Id);

            if (course.CatagoryId < 1)
            {
                ModelState.AddModelError("", "catagory is required");
                ViewBag.Catagories = db.CourseCatagories.ToList();
                return View(course);
            }
            if (ModelState.IsValid)
            {
                if (course.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Course.Image);
                    System.IO.File.Delete(oldImagePath);

                    course.ImageFile.SaveAs(imagePath);
                    Course.Image = imageName;
                }

                Course.Title = course.Title;
                Course.Explanation = course.Explanation;
                Course.Content = course.Content;
                Course.CatagoryId = course.CatagoryId;
                Course.StartDate = course.StartDate;
                Course.Duration = course.Duration;
                Course.ClassDuration = course.ClassDuration;
                Course.SkillLevel = course.SkillLevel;
                Course.Language = course.Language;
                Course.StudentCount  = course.StudentCount;
                Course.Assesments = course.Assesments;
                Course.Price = course.Price;

                db.Entry(Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.Catagories = db.CourseCatagories.ToList();
            return View(Course);
        }

        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            if (course== null)
            {
                return HttpNotFound();
            }
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}