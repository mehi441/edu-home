using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration



        EduHomeContex db = new EduHomeContex();

        public ActionResult Register()
        {
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();

            return View();
        }

        [HttpPost]
        public ActionResult Register( User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(a => a.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "this username is used");
                    return View(user);
                }

                if (db.Users.Any(a => a.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "this email is used");
                    return View(user);
                }

                if (db.Users.Any(a => a.Phone == user.Phone))
                {
                    ModelState.AddModelError("Phone", "this phone is used");
                    return View(user);
                }

                if (user.ImageFile == null)
                {
                    ModelState.AddModelError("ImageFile", "image is requred");
                    return View(user);
                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + user.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    user.ImageFile.SaveAs(imagePath);
                    user.Image = imageName;
                }
                
                user.Password = Crypto.HashPassword(user.Password);

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "Login");
            }

            return View(user);
        }





    }
}