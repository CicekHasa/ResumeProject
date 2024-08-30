using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;
namespace ResumeProject.Controllers
{
    public class ContactController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewTheMessage(int id)
        {
            var value=db.TblContact.Find(id);
            return View(value);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            //Category tablosundaki CategoryName'i dropdown'a atama 
            List<SelectListItem> values = (from x in db.TblCategory.ToList()//tblcategory deki bilgileri x'e ata.
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName, //Dropdown içindeki text yani kişiye gözükücek yazı x den gelen category name
                                               Value = x.CategoryID.ToString() //Seçilen category name in id değerini de value ye ata.
                                           }).ToList();

            ViewBag.v = values;//values'e atadığım değerleri v değişkenine yolladım.
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(TblContact p)
        {
            //p.Date=DateTime.Now;//Bu da olur.
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());//Bugünün kısa tarihini verir.
            db.TblContact.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index","Default");//2. parametre hangi controller'a gitmek istediğini belirtir.
        }

        public PartialViewResult PartialMap()
        {
            return PartialView();
        }

        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

    }
}