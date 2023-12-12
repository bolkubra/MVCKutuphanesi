using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCKutuphanesi.Models.Entity;

namespace MVCKutuphanesi.Controllers
{
    [AllowAnonymous] // olmazsa hiç bir sayfaya erişim sağlanmaz
    public class LoginController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Login
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYE t)
        {
            var bilgiler = db.TBLUYE.FirstOrDefault(x=>x.EMAIL==t.EMAIL && x.SIFRE==t.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.EMAIL, false);
                Session["Email"] = bilgiler.EMAIL.ToString();
                //TempData["Ad"] = bilgiler.AD.ToString();
                //TempData["Id"] = bilgiler.ID.ToString();
                //TempData["SoyAd"] = bilgiler.SOYAD.ToString();
                //TempData["KullanıcıAdı"] = bilgiler.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgiler.SIFRE.ToString();
                //TempData["Telefon"] = bilgiler.TELEFON.ToString();
                //TempData["Okul"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
           
        }
    }
}