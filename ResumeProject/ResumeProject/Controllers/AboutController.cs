using Newtonsoft.Json.Linq;
using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAbout()
        {
            return PartialView();
        }
        public PartialViewResult PartialSkills()
        {
            var viewModel = new ProfileTechnologyViewModel
            {
                Profiles = db.TblProfile.ToList(),       // Bu kısımda veritabanından gerekli verileri çekiyorsunuz
                Technologies = db.TblTechnology.ToList() // Burada da diğer tablodan verileri çekiyorsunuz
            };
            return PartialView(viewModel);
        }
        public PartialViewResult PartialPageVideo()
        {
            return PartialView();
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialReference()
        {
            var values = db.TblReferences.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }

    public class ProfileTechnologyViewModel
    {
        public List<TblProfile> Profiles { get; set; }
        public List<TblTechnology> Technologies { get; set; }
    }
}