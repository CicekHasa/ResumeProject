using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class SolutionController : Controller
    {
        // GET: Solution
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblSolution.ToList();
            return View(values);
        }
        public ActionResult DeleteSolution(int id)
        {
            var values = db.TblSolution.Find(id);
            db.TblSolution.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSolution(int id)
        {
            var values=db.TblSolution.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSolution(TblSolution p)
        {
            var values = db.TblSolution.Find(p.SolutionID);
            values.SolutionName = p.SolutionName;
            values.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddSolution()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSolution(TblSolution p)
        {
            db.TblSolution.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}