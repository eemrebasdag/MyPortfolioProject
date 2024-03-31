using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblServices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddServices()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddServices(TblService service)
        {
            db.TblServices.Add(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateServices(int id)
        {
            var value = db.TblServices.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateServices(TblService service)
        {
            var value = db.TblServices.Find(service.ServiceId);
            value.Title = service.Title;
            value.Description = service.Description;
            value.Icon = service.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult DeleteServices(int id)
        {
            var value = db.TblServices.Find(id);
            db.TblServices.Remove(value);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult MakeActive(int id)
        {
            var value = db.TblServices.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult MakePassive(int id)
        {
            var value = db.TblServices.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}