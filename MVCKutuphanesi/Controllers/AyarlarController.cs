using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphanesi.Models.Entity;

namespace MVCKutuphanesi.Controllers
{
    [AllowAnonymous]
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var kullanici = db.TBLADMIN.ToList();
            return View(kullanici);
        }
        public ActionResult Index2()
        {
            var kullanici = db.TBLADMIN.ToList();
            return View(kullanici);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN a)
        {
            db.TBLADMIN.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        public ActionResult AdminSil(int id)
        {
            var admn = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(admn);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admn = db.TBLADMIN.Find(id);
            return View("AdminGuncelle" , admn);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN a)
        {
            var admn = db.TBLADMIN.Find(a.ID);
            admn.KULLANICIADI = a.KULLANICIADI;
            admn.SIFRE = a.SIFRE;
            admn.YETKI = a.YETKI;
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}