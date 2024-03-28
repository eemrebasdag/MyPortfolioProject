using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();   
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial testimonial)
        {
            db.TblTestimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            return View(value); 
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial testimonial)
        {
            var value = db.TblTestimonials.Find(testimonial.TestimonialId);
            value.ImageUrl = testimonial.ImageUrl;
            value.Comment = testimonial.Comment;
            value.Title = testimonial.Title;
            value.Status = testimonial.Status;
            value.NameSurname = testimonial.NameSurname;    
            value.CommentDate = testimonial.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult MakeActive(int id)
        {
            var value = db.TblTestimonials.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult MakePassive(int id)
        {
            var value = db.TblTestimonials.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}