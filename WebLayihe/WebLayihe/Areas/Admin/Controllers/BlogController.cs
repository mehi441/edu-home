using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        // GET: Admin/Blog

        // CRUD BLog
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Blog> blogs = db.Blogs.Include("Catagory").ToList();
            return View(blogs);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }
         // CREATE
        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
           ViewBag.Catagories = db.BlogCatagories.ToList();
            return View();
            }
            return RedirectToAction("Login", "RegisterAdmin");


 
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog)
        {

            if (blog.CatagoryId < 1)
            {
                ModelState.AddModelError("", "catagory is required");
                ViewBag.Catagories = db.BlogCatagories.ToList();
                return View(blog);
            }

            if (ModelState.IsValid)
            {
                if (blog.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    ViewBag.Catagories = db.BlogCatagories.ToList();
                    return View(blog);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    blog.ImageFile.SaveAs(imagePath);
                    blog.Image = imageName;
                }

                db.Blogs.Add(blog);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            ViewBag.Catagories = db.BlogCatagories.ToList();
            return View();
        }
         // UPDATE

        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
 Blog blog = db.Blogs.Find(id);
            if (blog==null)
            {
                return HttpNotFound();
            }
            ViewBag.Catagories = db.BlogCatagories.ToList();
            return View(blog);
            }
            return RedirectToAction("Login", "RegisterAdmin");


           
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Blog blog)
        {
            Blog Blog = db.Blogs.Find(blog.Id);
            if (blog.CatagoryId < 1)
            {
                ModelState.AddModelError("", "catagory is required");
                ViewBag.Catagories = db.BlogCatagories.ToList();
                return View(Blog);
            }

            if (ModelState.IsValid)
            {
                if (blog.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Blog.Image);
                    System.IO.File.Delete(oldImagePath);

                    blog.ImageFile.SaveAs(imagePath);
                    Blog.Image = imageName;
                }

                Blog.Title = blog.Title;
                Blog.Content = blog.Content;
                Blog.Author = blog.Author;
                Blog.CatagoryId = blog.CatagoryId;

                db.Entry(Blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Catagories = db.BlogCatagories.ToList();
            return View(Blog);
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
            Blog blog = db.Blogs.Find(id);
            if (blog==null)
            {
                return HttpNotFound();
            }
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }


    }
}