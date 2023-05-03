using RezidaslarMVCkatman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;


namespace RezidaslarMVCkatman.Controllers
{
    public class HizmetlerKullaniciController : Controller
    {
        // GET: HizmetlerKullanici
        public ActionResult Index()
        {
            IEnumerable<mvcHizmetlerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Hizmetlers").Result;
            listele = response.Content.ReadAsAsync<IEnumerable<mvcHizmetlerModel>>().Result;
            return View(listele);
        }

        public ActionResult EY(int id=0)
        {
            if (id == 0)
            {
                return View(new mvcHizmetlerModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Hizmetlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcHizmetlerModel>().Result);
            }

            
        }
        public ActionResult EY(mvcHizmetlerModel hizmet)
        {
            if (hizmet.HizmetNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Hizmetlers", hizmet).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Hizmetlers/" + hizmet.HizmetNo, hizmet).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Hizmetlers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}