using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;
namespace ResumeProject.Controllers
{
    public class TopicController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblTopic.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTopic()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTopic(TblTopic p)
        {
            db.TblTopic.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTopic(int id)
        {
            var value = db.TblTopic.Find(id);
            db.TblTopic.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTopic(int id)
        {
            var value = db.TblTopic.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTopic(TblTopic p)
        {
            var value = db.TblTopic.Find(p.topicID);
            value.topictitle = p.topictitle;
            value.topicDescription = p.topicDescription;
            value.topicIcon= p.topicIcon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}