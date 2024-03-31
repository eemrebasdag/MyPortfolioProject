using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values);
        }

        [HttpGet]   
        public ActionResult DeleteMessages(int id)
        {
            var value = db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}