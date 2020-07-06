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
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        // CONTACT CRUD
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Contact> contacts = db.Contacts.ToList();
            return View(contacts);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    return View(contact);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    contact.ImageFile.SaveAs(imagePath);
                    contact.Image = imageName;
                }
                db.Contacts.Add(contact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public ActionResult Update(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            Contact Contact = db.Contacts.Find(contact.Id);

            if (ModelState.IsValid)
            {
                if (contact.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Contact.Image);
                    System.IO.File.Delete(oldImagePath);

                    contact.ImageFile.SaveAs(imagePath);
                    Contact.Image = imageName;
                }

                Contact.Title = contact.Title;
                Contact.FirstAddress = contact.FirstAddress;
                Contact.SecondAddress = contact.SecondAddress;

                db.Entry(Contact).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            return View(Contact);
        }

        public ActionResult Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }












    }
}