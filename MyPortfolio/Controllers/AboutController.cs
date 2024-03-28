using MyPortfolio.Models;
using MyPortfolio.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{

    public class AboutController : Controller
    {
        // GET: About
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        public ActionResult Index()
        {
            ViewBag.user = Session["userName"];
            var values = db.TblAbouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }


        [HttpPost]

        public ActionResult AddAbout(TblAbout about)
        {
            db.TblAbouts.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DeleteAbout(int id)
        {
            var about = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateAbout(int id)
        {
            var about = db.TblAbouts.Find(id);
            return View(about);
        }

        [HttpPost]

        public ActionResult UpdateAbout(TblAbout about)
        {
            var value  = db.TblAbouts.Find(about.AboutId);
            value.ImageUrl = about.ImageUrl;
            value.Title = about.Title;
            value.Description = about.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}