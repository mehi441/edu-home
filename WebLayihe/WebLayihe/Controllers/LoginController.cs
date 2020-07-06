using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebLayihe.DAL;
using WebLayihe.Models;

namespace WebLayihe.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login


        EduHomeContex db = new EduHomeContex();



        public ActionResult Login()
        {
            ViewBag.Setting = db.Settings.Include("SettingSocials").FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewModels.Login login)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(a => a.Username == login.Username);

                if (user != null)
                {
                    if (Crypto.VerifyHashedPassword(user.Password, login.Password))
                    {
                        Session["User"] = true;
                        Session["UserId"] = user.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Wrong password or username");
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Wrong username");
                    return View(login);
                }
            }
            return View(login);
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            Session["UserId"] = null;

            return RedirectToAction("Index", "Home");
        }



    }
}