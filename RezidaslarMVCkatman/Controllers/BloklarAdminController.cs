using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using RezidaslarMVCkatman.Models;

namespace RezidaslarMVCkatman.Controllers
{
    public class BloklarAdminController : Controller
    {
        // GET: BloklarAdmin
        public ActionResult Index()
        {
            IEnumerable<mvcBloklarModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Bloklars").Result;

            listele = response.Content.ReadAsAsync<IEnumerable<mvcBloklarModel>>().Result;

            return View(listele);
        }

        public ActionResult EY(int id = 0)
        {
            if (id==0)
            {
                return View(new mvcBloklarModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Bloklars/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcBloklarModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(mvcBloklarModel blok)
        {
            if (blok.BlokNo==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Bloklars", blok).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Bloklars/" + blok.BlokNo, blok).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Bloklars/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}