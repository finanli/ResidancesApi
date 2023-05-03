using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RezidaslarMVCkatman.Models;
using System.Net.Http;

namespace RezidaslarMVCkatman.Controllers
{
    public class GorevlerAdminController : Controller
    {
        // GET: GorevlerAdmin
        public ActionResult Index()
        {
            IEnumerable<mvcGorevlerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Gorevlers").Result;

            listele = response.Content.ReadAsAsync<IEnumerable<mvcGorevlerModel>>().Result;
            return View(listele);
        }

       
    }
}