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
    public class SettingController : Controller
    {
        // GET: Admin/Setting
        // CRUD Settings
        EduHomeContex db = new EduHomeContex();
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
            {
            List<Setting> settings = db.Settings.ToList();
            return View(settings);
            }
            return RedirectToAction("Login", "RegisterAdmin");



        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                // check logo image validation
                if (setting.LogoFile == null)
                {
                    ModelState.AddModelError("LogoFile", " logo Image is requred");
                    return View(setting);
                }
                else
                {
                    string logoImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.LogoFile.FileName;
                    string logoImagePath = Path.Combine(Server.MapPath("~/Uploads/"), logoImageName);

                    setting.LogoFile.SaveAs(logoImagePath);
                    setting.Logo = logoImageName;
                }

                // check back ground image validation
                if (setting.BgImageFile == null)
                {
                    ModelState.AddModelError("BgImageFile", " Background Image is requred");
                    return View(setting);
                }
                else
                {
                    string bgImageFileName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.BgImageFile.FileName;
                    string bgImageFilePath = Path.Combine(Server.MapPath("~/Uploads/"), bgImageFileName);

                    setting.BgImageFile.SaveAs(bgImageFilePath);
                    setting.BgImage = bgImageFileName;
                }

                // check sidebar image validation
                if (setting.SidebarImageFile == null)
                {
                    ModelState.AddModelError("SidebarImageFile", " Background Image is requred");
                    return View(setting);
                }
                else
                {
                    string sidebarImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.SidebarImageFile.FileName;
                    string sidebarImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sidebarImageName);

                    setting.SidebarImageFile.SaveAs(sidebarImagePath);
                    setting.SidebarImage = sidebarImageName;
                }

                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }


        public ActionResult Update(int id)
        {
            Setting setting = db.Settings.Find(id);
            if (setting==null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        [HttpPost]

        public ActionResult Update(Setting setting)
        {
            Setting Setting = db.Settings.Find(setting.Id);
            if (ModelState.IsValid)
            {
                // check logo image is changed
                if (setting.LogoFile != null)
                {
                    string logoImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.LogoFile.FileName;
                    string logoImagePath = Path.Combine(Server.MapPath("~/Uploads/"), logoImageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Setting.Logo);
                    System.IO.File.Delete(oldImagePath);

                    setting.LogoFile.SaveAs(logoImagePath);
                    Setting.Logo = logoImageName;
                }

                // check back ground image is changed
                if (setting.BgImageFile != null)
                {
                    string bgImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.BgImageFile.FileName;
                    string bgImagePath = Path.Combine(Server.MapPath("~/Uploads/"), bgImageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Setting.BgImage);
                    System.IO.File.Delete(oldImagePath);

                    setting.BgImageFile.SaveAs(bgImagePath);
                    Setting.BgImage = bgImageName;
                }

                // check sidebar image is changed
                if (setting.SidebarImageFile != null)
                {
                    string sidebarImageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + setting.SidebarImageFile.FileName;
                    string sidebarImagePath = Path.Combine(Server.MapPath("~/Uploads/"), sidebarImageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), Setting.SidebarImage);
                    System.IO.File.Delete(oldImagePath);

                    setting.SidebarImageFile.SaveAs(sidebarImagePath);
                    Setting.SidebarImage = sidebarImageName;
                }

                Setting.NavbarPhone = setting.NavbarPhone;
                Setting.Content = setting.Content;
                Setting.Copyright = setting.Copyright;
                Setting.FistAddress = setting.FistAddress;
                Setting.SecondAddress = setting.SecondAddress;
                Setting.FirstPhone = setting.FirstPhone;
                Setting.SecondPhone = setting.SecondPhone;
                Setting.Email = setting.Email;

                db.Entry(Setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Setting);
        }


        public ActionResult Delete(int id)
        {
            Setting setting = db.Settings.Find(id);
            if (setting==null)
            {
                return HttpNotFound();
            }
            db.Settings.Remove(setting);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}