using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebLayihe.DAL;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        // GET: Admin/Message

        // rEAD Messages and delete

        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Models.Message> messages = db.Messages.ToList();
            return View(messages);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Delete(int id)
        {
            Models.Message message = db.Messages.Find(id);
            if (message==null)
            {
                return HttpNotFound();
            }
            db.Messages.Remove(message);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}