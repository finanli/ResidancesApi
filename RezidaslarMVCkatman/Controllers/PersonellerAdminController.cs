using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RezidaslarMVCkatman.Models;
using System.Net.Http;
using System.Net.Configuration;

namespace RezidaslarMVCkatman.Controllers
{
    public class PersonellerAdminController : Controller
    {
        // GET: PersonellerAdmin
        public ActionResult Index()
        {
            IEnumerable<mvcPersonellerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Personellers").Result;

            listele = response.Content.ReadAsAsync<IEnumerable<mvcPersonellerModel>>().Result;
            return View(listele);
        }

        

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Personellers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}