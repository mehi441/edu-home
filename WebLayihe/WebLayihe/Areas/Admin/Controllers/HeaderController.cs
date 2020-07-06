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
    public class HeaderController : Controller
    {
        // GET: Admin/Header
        // CRUD Heders
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Header> headers = db.Headers.ToList();
            return View(headers);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Header header)
        {
            if (ModelState.IsValid)
            {
                if (header.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    return View();
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + header.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    header.ImageFile.SaveAs(imagePath);
                    header.Image = imageName;
                }
                db.Headers.Add(header);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Update(int id)
        {
            Header header = db.Headers.Find(id);
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }


        [HttpPost]
        public ActionResult Update(Header header)
        {
            Header Header = db.Headers.Find(header.Id);

            if (ModelState.IsValid)
            {
                if (header.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + header.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Header.Image);
                    System.IO.File.Delete(oldImagePath);

                    header.ImageFile.SaveAs(imagePath);
                    Header.Image = imageName;
                }

                Header.Title = header.Title;
                Header.Page = header.Page;

                db.Entry(Header).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Header);
        }

        public ActionResult Delete(int id)
        {
            Header header = db.Headers.Find(id);
            if (header==null)
            {
                return HttpNotFound();
            }
            db.Headers.Remove(header);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}