using RezidaslarMVCkatman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RezidaslarMVCkatman.Controllers
{
    public class HomeController : Controller
    {
        RezidanslarEntities db = new RezidanslarEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Kullanicilar kullanici)
        {
            if (db.Kullanicilars.Any(x=> x.kullaniciAdi == kullanici.kullaniciAdi))
            {
                ViewBag.Notification = "Böyle Biri Var!";
                return RedirectToAction("SignUp", "Home");
            }
            else 
            {
                db.Kullanicilars.Add(kullanici);
                db.SaveChanges();
                Session["KullaniciNo"] = kullanici.kullaniciNo.ToString();
                Session["KullaniciAdi"] = kullanici.kullaniciAdi.ToString();
                return RedirectToAction("Login", "Home");
            }

            
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Kullanicilar kullanici)
        {
            var loginkontrol = db.Kullanicilars.Where(x => x.kullaniciAdi.Equals(kullanici.kullaniciAdi) && x.sifre.Equals(kullanici.sifre)).FirstOrDefault();
            if (loginkontrol != null)
            {
                Session["KullaniciAdi"] = kullanici.kullaniciNo.ToString();
                Session["sifre"] = kullanici.sifre.ToString();
                return RedirectToAction("Index", "PlazalarAdmin");
            }
            else
            {
                ViewBag.Notification = "Yanlış Kullanıcı Adi ya da Şifre Girdiniz.";
            }
            return View();
        }
    }
}