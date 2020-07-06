using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.ViewModels;

namespace WebLayihe.Controllers
{
    public class BlogDetailController : Controller
    {
        // GET: BlogDetail

        EduHomeContex db = new EduHomeContex();
        public ActionResult Index(int id)
        {
            VmBlogDetails vmBlogDetails = new VmBlogDetails();
            vmBlogDetails.Header = db.Headers.FirstOrDefault(h=> h.Page== "Blog Details");
            vmBlogDetails.Setting = db.Settings.FirstOrDefault();
            if (db.Blogs.Find(id)==null)
            {
                return RedirectToAction("Index","Blog");
            }

            vmBlogDetails.Blog = db.Blogs.Find(id);
            vmBlogDetails.BlogCatagories = db.BlogCatagories.ToList();
            vmBlogDetails.Blogs = db.Blogs.OrderByDescending(b => b.Id).Take(3).ToList();
            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmBlogDetails);
        }
    }
}