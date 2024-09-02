using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ResumeProject.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Reference
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblReferences.ToList();
            return View(values);
        }

        public ActionResult DeleteReference(int id)
        {
            var value = db.TblReferences.Find(id);
            db.TblReferences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateReference(int id)
        {
            var values = db.TblReferences.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateReference(TblReferences p)
        {
            try
            {
                var values = db.TblReferences.Find(p.ReferenceId);
                values.Name = p.Name;
                values.Job = p.Job;
                values.Description = p.Description;
                db.SaveChanges();
            }
            catch (Exception exc)
            {
                var value = exc.StackTrace;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddReference()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReference(TblReferences p)
        {
            db.TblReferences.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}