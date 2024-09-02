using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        DbResumeEntities db=new DbResumeEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialBanner()
        {
            return PartialView();
        }

        public PartialViewResult PartialSection()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSolution()
        {
            var values=db.TblSolution.ToList();
            return PartialView(values);
        }
    }
}