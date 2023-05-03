using RezidaslarMVCkatman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RezidaslarMVCkatman.Controllers
{
    public class HizmetlerAdminController : Controller
    {
        // GET: HizmetlerAdmin
        public ActionResult Index()
        {
            IEnumerable<mvcHizmetlerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Hizmetlers").Result;

            listele = response.Content.ReadAsAsync<IEnumerable<mvcHizmetlerModel>>().Result;
            return View(listele);
        }


    }
}