using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.TblFeatures.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblServices.Where(x=> x.Status == true).ToList();  
            return PartialView(values);
        }

        public PartialViewResult DefaultExperiencePartial()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultPortfolioPartial()
        {
            var categories = db.TblCategories.ToList();

            ViewBag.categories = categories;

            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestiomianlsPartial()
        {
            var values = db.TblTestimonials.Where(x => x.Status == true).ToList();
            return PartialView(values); 
        }

        public PartialViewResult DefaultTeamPartial()
        {
            var values = db.TblTeams.ToList();  
            return PartialView(values);
        }

        public PartialViewResult DefaultContactPartial()
        {
            var values = db.TblContacts.ToList();   
            return PartialView(values);
        }

        public PartialViewResult DefaultFooterPartial() 
        {
            var contacts = db.TblContacts.ToList();
            return PartialView(contacts);
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage message)
        {
            db.TblMessages.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}