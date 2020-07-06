using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class BlogCatagoryController : Controller
    {
        // GET: Admin/BlogCatagory

        // CRUD blog Catagories

        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<BlogCatagory> blogCatagories = db.BlogCatagories.ToList();
            return View(blogCatagories);
            }
            return RedirectToAction("Login", "RegisterAdmin");


        
        }

        public ActionResult Create()
        {
            if (Session["Admin"] != null)
            {
              return View();
           
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }


        [HttpPost]
        public ActionResult Create(BlogCatagory blogCatagory )
        {
            if (ModelState.IsValid)
            {
                db.BlogCatagories.Add(blogCatagory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogCatagory);
        }

        public ActionResult Update(int id)
        {
            if (Session["Admin"] != null)
            {
            BlogCatagory blogCatagory = db.BlogCatagories.Find(id);
            if (blogCatagory==null)
            {
                return HttpNotFound();
            }
            return View(blogCatagory);
            }
            return RedirectToAction("Login", "RegisterAdmin");




        }

        [HttpPost]
        public ActionResult Update(BlogCatagory blogCatagory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogCatagory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogCatagory); 
        }

        public ActionResult Delete(int id)
        {
            if (Session["Admin"] != null)
            {
            BlogCatagory blogCatagory = db.BlogCatagories.Find(id);
            if (blogCatagory==null)
            {
                return HttpNotFound();
            }
            db.BlogCatagories.Remove(blogCatagory);
            db.SaveChanges();
            return RedirectToAction("index");
            }
            return RedirectToAction("Login", "RegisterAdmin");





        }

    }
}