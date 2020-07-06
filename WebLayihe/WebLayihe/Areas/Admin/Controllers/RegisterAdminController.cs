using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebLayihe.DAL;

namespace WebLayihe.Areas.Admin.Controllers
{
    public class RegisterAdminController : Controller
    {
        // GET: Admin/RegisterAdmin

        EduHomeContex db = new EduHomeContex();

        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "RegisterAdmin");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ViewModels.Login login)
        {
            if (ModelState.IsValid)
            {
                Models.Admin admin = db.Admins.FirstOrDefault(a => a.Username == login.Username);

                if (admin!=null)
                {
                    if (Crypto.VerifyHashedPassword(admin.Password,login.Password))
                    {
                        Session["Admin"] = true;
                        Session["AdminId"] = admin.Id;

                        return RedirectToAction("Index","RegisterAdmin");
                    }
                    else
                    {
                        ModelState.AddModelError("Password","Wrong password or username");
                        return View(login);
                    }
                }
                else
                {
                    ModelState.AddModelError("Username","Wrong username");
                    return View(login);
                }
            }
            return View(login);
        }


        public ActionResult Register()
        {

            if (Session["Admin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "RegisterAdmin");

        }

        [HttpPost]
        public ActionResult Register(Models.Admin admin)
        {
            
                if (ModelState.IsValid)
                {
                    if (db.Admins.Any(a => a.Username == admin.Username))
                    {
                        ModelState.AddModelError("Username", "this username is used");
                        return View(admin);
                    }

                    admin.Password = Crypto.HashPassword(admin.Password);

                    db.Admins.Add(admin);
                    db.SaveChanges();
                    return RedirectToAction("Login", "RegisterAdmin");
                }

                return View(admin);
         
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            Session["AdminId"] = null;

            return RedirectToAction("Login", "RegisterAdmin");
        }










    }
}