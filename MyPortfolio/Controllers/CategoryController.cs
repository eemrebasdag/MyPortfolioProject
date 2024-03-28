using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblCategories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(TblCategory category)
        {
            db.TblCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
            var value = db.TblCategories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory category) 
        {
            var value = db.TblCategories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public ActionResult DeleteCategory(int id)
        {
            var value = db.TblCategories.Find(id);
            db.TblCategories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}