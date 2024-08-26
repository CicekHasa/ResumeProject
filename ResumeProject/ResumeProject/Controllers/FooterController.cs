using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer

        DbResumeEntities db=new DbResumeEntities();
        public ActionResult Index1()
        {
            var values = db.Tblfooter.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFooterInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFooterInfo(Tblfooter p)
        {
            db.Tblfooter.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        public ActionResult DeleteFooterInfo(int id)
        {
            var values=db.Tblfooter.Find(id);
            db.Tblfooter.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }

        [HttpGet]
        public ActionResult UpdateFooterInfo(int id) 
        {
            var values = db.Tblfooter.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFooterInfo(Tblfooter p)
        {
            var values = db.Tblfooter.Find(p.FooterID);
            values.FooterTel = p.FooterTel;
            values.FooterMail = p.FooterMail;
            values.FooterAdress = p.FooterAdress;
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
    }
}