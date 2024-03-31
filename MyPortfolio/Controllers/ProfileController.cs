using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblAdmins.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProfiles()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProfiles(TblAdmin profile)
        {
            db.TblAdmins.Add(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProfiles(int id)
        {
            var value = db.TblAdmins.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProfiles(TblAdmin profile)
        {
            var value = db.TblAdmins.Find(profile.AdminId);
            value.UserName = profile.UserName;
            value.Password = profile.Password;
            value.ImageUrl = profile.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DeleteProfiles(int id)
        {
            var value = db.TblAdmins.Find(id);
            db.TblAdmins.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}