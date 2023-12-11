﻿using MVCKutuphanesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKutuphanesi.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBLUYE.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD +" "+ x.SOYAD,
                                               Value = x.ID.ToString()
                                               
                                           }
                                          ).ToList() ;

            List<SelectListItem> deger2 = (from x in db.TBLKITAP.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()

                                           }
                                          ).ToList();

            List<SelectListItem> deger3 = (from x in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()

                                           }
                                        ).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            var d1 = db.TBLUYE.Where(x => x.ID == p.TBLUYE.ID).FirstOrDefault(); // dropdowndan gelen değerleri değişkenlere atadık
            var d2 = db.TBLKITAP.Where(y => y.ID == p.TBLKITAP.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(z => z.ID == p.TBLPERSONEL.ID).FirstOrDefault();
            p.TBLUYE = d1;
            p.TBLKITAP = d2;
            p.TBLPERSONEL = d3; 

            db.TBLHAREKET.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Odunciade(TBLHAREKET p)
        {
           
            var odn = db.TBLHAREKET.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIHI.ToString());
            DateTime d2 = DateTime.Parse(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;

            return View("Odunciade", odn);

        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk = db.TBLHAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}