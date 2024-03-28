using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblFeatures.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(TblFeature feature) 
        {
            db.TblFeatures.Add(feature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id) 
        {
            var value = db.TblFeatures.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature feature) 
        {
            var value = db.TblFeatures.Find(feature.FeatureId);
            value.ImageUrl = feature.ImageUrl;
            value.NameSurname = feature.NameSurname;
            value.Title = feature.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}