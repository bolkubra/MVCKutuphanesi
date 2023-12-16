using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVCKutuphanesi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCKutuphanesi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLUYE.ToList();
            var degerler = db.TBLUYE.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUYE p)
        {
            if (!ModelState.IsValid) 
            {
                return View("UyeEkle");
            }
            db.TBLUYE.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYE.Find(id);
            db.TBLUYE.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYE.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYE p)
        {
            var uye = db.TBLUYE.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.EMAIL = p.EMAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgecmis = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBLUYE.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.k1 = uyekit;
            return View(ktpgecmis);
        }
    }
}