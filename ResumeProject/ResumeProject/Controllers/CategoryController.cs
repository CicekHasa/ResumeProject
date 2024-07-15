using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;
namespace ResumeProject.Controllers
{
    public class CategoryController : Controller
    {
        DbResumeEntities db=new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblCategory.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory p)
        {
            db.TblCategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value=db.TblCategory.Find(id);
            db.TblCategory.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value=db.TblCategory.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(TblCategory p)
        {
            var value = db.TblCategory.Find(p.CategoryID);
            value.CategoryID = p.CategoryID;
            value.CategoryName = p.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetMessageBySubject(int id)
        {
            var value = db.TblContact.Where(x => x.Subject == id).ToList();
            return View(value);
        }

        public ActionResult ViewTheMessage(int id)
        {
            var value=db.TblContact.Find(id);
            return View(value);
        }

    }
}