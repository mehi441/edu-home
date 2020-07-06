using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Admin/Teacher

        // CRUD Teacher

        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Teacher> teachers = db.Teachers.Include("Occupation").ToList(); 
            return View(teachers);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            ViewBag.Occupations = db.Occupations.ToList();
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Teacher teacher)
        {
            if (teacher.OccupationId < 1)
            {
                ModelState.AddModelError("", "occupation is required");
                ViewBag.Occupations = db.Occupations.ToList();
                return View(teacher);
            }

            if (ModelState.IsValid)
            {
                if (teacher.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    ViewBag.Occupations = db.Occupations.ToList();
                    return View(teacher);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    teacher.ImageFile.SaveAs(imagePath);
                    teacher.Image = imageName;
                }

                db.Teachers.Add(teacher);
                db.SaveChanges();

                return RedirectToAction("Index");
            }



            ViewBag.Occupations = db.Occupations.ToList();
            return View();
        }


        public ActionResult Update(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher==null)
            {
                return HttpNotFound();
            }
            ViewBag.Occupations = db.Occupations.ToList();
            return View(teacher);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Teacher teacher)
        {
            Teacher Teacher = db.Teachers.Find(teacher.Id);
            if (teacher.OccupationId < 1)
            {
                ModelState.AddModelError("", "occupation is required");
                ViewBag.Occupations = db.Occupations.ToList();
                return View(Teacher);
            }
            if (ModelState.IsValid)
            {
                if (teacher.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Teacher.Image);
                    System.IO.File.Delete(oldImagePath);

                    teacher.ImageFile.SaveAs(imagePath);
                    Teacher.Image = imageName;
                }

                Teacher.Fullname = teacher.Fullname;
                Teacher.OccupationId = teacher.OccupationId;
                Teacher.Content = teacher.Content;
                Teacher.Email = teacher.Email;
                Teacher.Phone = teacher.Phone;
                Teacher.Skype = teacher.Skype;
                Teacher.Language = teacher.Language;
                Teacher.TeamLeader = teacher.TeamLeader;
                Teacher.Development = teacher.Development;
                Teacher.Design = teacher.Design;
                Teacher.Innovation = teacher.Innovation;
                Teacher.Communication = teacher.Communication;

                db.Entry(Teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Occupations = db.Occupations.ToList();
            return View(Teacher);
        }

        public ActionResult Delete(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher==null)
            {
                return HttpNotFound();
            }
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}