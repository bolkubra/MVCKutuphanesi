using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKutuphanesi.Models.Entity;
namespace MVCKutuphanesi.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Email"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x=>x.ALICI == uyemail.ToString()).ToList(); // kişiye gelen mesajlar
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var uyemail = (string)Session["Email"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList(); // kişiye gelen mesajlar
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemail = (string)Session["Email"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar", "Mesajlar");
        }
    }
}