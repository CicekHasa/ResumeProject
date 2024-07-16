using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;
namespace ResumeProject.Controllers
{
    public class StatisticController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            //ViewBag.skillCount = db.TblSkill.Count();//tablodaki toplam kayıt sayısını verir.
            ViewBag.countProjeTalebi = db.CountProjeTalebi().FirstOrDefault();//Db de oluşturduğum prosedürümü models'e ekleyip kullandım.
            ViewBag.technologyCount = db.TblTechnology.Count();
            ViewBag.csharpValue = db.TblTechnology.Where(X => X.TechnologyTitle == "C#").Select(y => y.TechnologyValue).FirstOrDefault();//başlık c# olan satırın value'sini getir. Değeri döndürmesi için ya ToList() ya da firstOrDefault() olmalı!!! 
            ViewBag.contactCount = db.TblContact.Count();
            ViewBag.subjectTesekkur = db.TblContact.Where(x => x.Subject == 1).Count();
            ViewBag.sumTechnologyValue = db.TblTechnology.Sum(x => x.TechnologyValue);
            ViewBag.averageTechnologyValue = db.TblTechnology.Average(x => x.TechnologyValue);
            ViewBag.getBy3Id = db.TblSkill.Where(x => x.SkillID == 3).Select(y => y.SkillTitle).FirstOrDefault();
            ViewBag.maxTechnologyValue=db.TblTechnology.Max(x => x.TechnologyValue);
            return View();
        }
    }
}