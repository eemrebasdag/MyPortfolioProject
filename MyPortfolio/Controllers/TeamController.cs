using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblTeams.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(TblTeam team)
        {
            db.TblTeams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var value = db.TblTeams.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTeam(TblTeam team)
        {
            var value = db.TblTeams.Find(team.TeamId);
            value.ImageUrl = team.ImageUrl;
            value.FacebookUrl = team.FacebookUrl;
            value.NameSurname = team.NameSurname;
            value.TwitterUrl = team.TwitterUrl;
            value.Description = team.Description;
            value.InstagramUrl = team.InstagramUrl;
            value.TwitterUrl = team.TwitterUrl;
            value.Title = team.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteTeam(int id)
        {
            var value = db.TblTeams.Find(id);
            db.TblTeams.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}