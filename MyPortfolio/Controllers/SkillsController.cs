using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblSkills.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddSkill(TblSkill skill)
        {
            db.TblSkills.Add(skill);    
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id) 
        {
            var value = db.TblSkills.Find(id);
            return View(value);
        }


        [HttpPost]

        public ActionResult UpdateSkill(TblSkill skill)
        {
            var value = db.TblSkills.Find(skill.SkillId);
            value.SkillName = skill.SkillName;
            db.SaveChanges();   
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkills.Find(id);
            db.TblSkills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}