using MVCKutuphanesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCKutuphanesi.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {
        // GET: Panelim
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
       
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Email"];
            //var degerler = db.TBLUYE.FirstOrDefault(z => z.EMAIL == uyemail);
            var degerler = db.TBLDUYURULAR.ToList();
            var d1 = db.TBLUYE.Where(x => x.EMAIL == uyemail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.TBLUYE.Where(x => x.EMAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;
            var d3 = db.TBLUYE.Where(x => x.EMAIL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;
            var d4 = db.TBLUYE.Where(x => x.EMAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;
            var d5 = db.TBLUYE.Where(x => x.EMAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;
            var d6 = db.TBLUYE.Where(x => x.EMAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;
            var uyeid = db.TBLUYE.Where(x => x.EMAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var d7 = db.TBLHAREKET.Where(x => x.UYE == uyeid).Count();
            ViewBag.d7 = d7;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index(TBLUYE t)
        {
            var kullanici = (string)Session["Email"];
            var uye = db.TBLUYE.FirstOrDefault(x => x.EMAIL == kullanici);
            uye.SIFRE = t.SIFRE;
            uye.AD = t.AD;
            uye.SOYAD = t.SOYAD;
            uye.KULLANICIADI = t.KULLANICIADI;
            uye.FOTOGRAF = t.FOTOGRAF;
            uye.OKUL = t.OKUL;
            uye.TELEFON = t.TELEFON;
            db.SaveChanges();
            return View();
        }
        public ActionResult Kitaplar()
        {
            var kullanici = (string)Session["Email"];
            var id = db.TBLUYE.Where(x => x.EMAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        
        public ActionResult Duyurular()
        {
            var duyurulist = db.TBLDUYURULAR.ToList();
            return View(duyurulist);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        public PartialViewResult Partial1() // parçalı wiew oluşturma
        {
            return PartialView();
        }
        public PartialViewResult Partial2() // parçalı wiew oluşturma
        {
            var kullanici = (string)Session["Email"];
            var id = db.TBLUYE.Where(x => x.EMAIL == kullanici).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.TBLUYE.Find(id);
            return PartialView("Partial2",uyebul);
        }
    }
}