using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Models;//Models klsörünün içindekilere ulaşmak için yazmamız gerek!
namespace ResumeProject.Controllers
{
    public class SkillController : Controller
    {
        DbResumeEntities db = new DbResumeEntities();//Models klasöründeki tablolara erişmek için!
        public ActionResult Index()
        {
            var values = db.TblSkill.ToList();
            return View(values);//Geriye bir sayfa döndürüyor. İçinde de benim tablomdaki değerleri yazarak döndürmesi için parametrede yolladım.
        }
        [HttpGet]//Attribute(Nitelik)
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]//Butona tıklandığında çalışan bir kısım
        public ActionResult AddSkill(TblSkill p)//Burada gelen verileri db ye kayıt edeceğiz.
        {
            db.TblSkill.Add(p);
            db.SaveChanges();//Verileri db ye kayıt etmek için kullanılır.
            return RedirectToAction("Index");//farklı bir action'a gitmek için kullanılır.Eklediğim kayıdı hemen listede görmek için oraya gittim! 
        }

        public ActionResult DeleteSkill(int id)
        {
            var value=db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var values = db.TblSkill.Find(id);//id ye göre gelen satırdaki verileri values'e ata
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkill p)//textboxlarda doldurduğumuz değerler yüklenir.
        {
            var values=db.TblSkill.Find(p.SkillID);//skillid ye göre db deki eski değerleri bul ve values'e ata.
            values.SkillTitle = p.SkillTitle;//eski skilltitle'ı değiş.
            values.SkillDescription = p.SkillDescription;
            values.SkillIcon = p.SkillIcon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}