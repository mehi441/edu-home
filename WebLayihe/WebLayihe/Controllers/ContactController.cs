using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.ViewModels;

namespace WebLayihe.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            VmContact vmContact = new VmContact();
            vmContact.Header = db.Headers.FirstOrDefault(h=> h.Page=="Contact");
            vmContact.Contacts = db.Contacts.ToList();
            if (Session["User"] != null)
            {
                ViewData["Username"] = db.Users.Find(Session["UserId"]).Username;
            }
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View(vmContact);
        }


        [HttpPost]
        public ActionResult Subscribe(string email)
        {
            Models.Subscribe subscribe = new Models.Subscribe();
            subscribe.AddedDate = DateTime.Now;
            subscribe.Email = email;
            db.Subscribes.Add(subscribe);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }





    }
}