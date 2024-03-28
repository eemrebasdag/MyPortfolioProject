﻿using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }


        public ActionResult AddProject() 
        {
            var categories = db.TblCategories.ToList();

            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),
                                                 }).ToList();

            ViewBag.category = categoryList;
            return View();
        }


        [HttpPost]

        public ActionResult AddProject(TblProject project)
        {
            db.TblProjects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]

        public ActionResult UpdateProject(int id)
        {
            var value = db.TblProjects.Find(id);
            var categories = db.TblCategories.ToList();

            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),
                                                 }).ToList();

            ViewBag.category = categoryList;
            return View(value);
        }

        [HttpPost]

        public ActionResult UpdateProject(TblProject project) 
        {
            var value = db.TblProjects.Find(project.ProjectId);
            value.ImageUrl = project.ImageUrl;
            value.ProjectName = project.ProjectName;
            value.CategoryId = project.CategoryId;
            value.GithubUrl = project.GithubUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}