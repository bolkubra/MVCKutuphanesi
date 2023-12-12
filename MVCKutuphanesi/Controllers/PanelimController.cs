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
            var degerler = db.TBLUYE.FirstOrDefault(z => z.EMAIL == uyemail);
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
    }
}