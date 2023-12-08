using MVCKutuphanesi.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKutuphanesi.Controllers
{
    public class KayitOlController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: KayitOl
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLUYE p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYE.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}