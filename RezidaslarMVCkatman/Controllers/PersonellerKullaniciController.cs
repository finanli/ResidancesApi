using RezidaslarMVCkatman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RezidaslarMVCkatman.Controllers
{
    public class PersonellerKullaniciController : Controller
    {
        // GET: PersonellerKullanici
        public ActionResult Index()
        {
            IEnumerable<mvcPersonellerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Personellers").Result;

            listele = response.Content.ReadAsAsync<IEnumerable<mvcPersonellerModel>>().Result;
            return View(listele);
        }

        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcPersonellerModel());

            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Personellers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPersonellerModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(mvcPersonellerModel personel)
        {
            if (personel.PersonelNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Personellers", personel).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Personellers/" + personel.PersonelNo, personel).Result;
            }

            return RedirectToAction("Index");
        }
    }
}