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
    public class BlogController : Controller
    {
        // GET: Blog
        // BLOGS PAGE
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index(int page=1)
        {
            VmBlog vmBlog = new VmBlog();
            vmBlog.Header = db.Headers.FirstOrDefault(h=> h.Page=="Blog");
            vmBlog.Setting = db.Settings.FirstOrDefault();
            vmBlog.BlogCatagories = db.BlogCatagories.ToList();

            vmBlog.Blogs = db.Blogs.OrderByDescending(b => b.Id).Skip((page - 1) * 6).Take(6).Include("Catagory").ToList();
            vmBlog.PageCount = Convert.ToInt32(Math.Ceiling(db.Blogs.Count() / 6.0));
            vmBlog.CurrentPage = page;

            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmBlog);
        }
    }
}