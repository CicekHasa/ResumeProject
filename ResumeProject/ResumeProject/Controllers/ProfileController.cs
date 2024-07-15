using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;
namespace ResumeProject.Controllers
{
    public class ProfileController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblProfile.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProfile(TblProfile p)
        {
            db.TblProfile.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            db.TblProfile.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id) 
        {
            var value= db.TblProfile.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProfile(TblProfile p)
        {
            var value=db.TblProfile.Find(p.ProfileID);
            value.ProfileTitle = p.ProfileTitle;
            value.ProfileDescription = p.ProfileDescription;
            value.Name = p.Name;
            value.Mail = p.Mail;
            value.Adress = p.Adress;
            value.Phone = p.Phone;
            value.SocialMedia1 = p.SocialMedia1;
            value.SocialMedia2 = p.SocialMedia2;
            value.SocialMedia3 = p.SocialMedia3;
            value.SocialMedia4 = p.SocialMedia4;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}