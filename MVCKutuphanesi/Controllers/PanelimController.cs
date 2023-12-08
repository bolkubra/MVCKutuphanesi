using MVCKutuphanesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKutuphanesi.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [Authorize]
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
            uye.OKUL=t.OKUL;
            uye.TELEFON = t.TELEFON;
            db.SaveChanges();
            return View();
        }
    }
}