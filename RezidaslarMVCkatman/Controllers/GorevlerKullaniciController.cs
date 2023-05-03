using RezidaslarMVCkatman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace RezidaslarMVCkatman.Controllers
{
    public class GorevlerKullaniciController : Controller
    {
        // GET: GorevlerKullanici
        public ActionResult Index()
        {
            IEnumerable<mvcGorevlerModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Gorevlers").Result;

            listele = response.Content.ReadAsAsync<IEnumerable<mvcGorevlerModel>>().Result;
            return View(listele);
        }

        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcGorevlerModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Gorevlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcGorevlerModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(mvcGorevlerModel gorev)
        {
            if (gorev.GorevNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Gorevlers", gorev).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Gorevlers/" + gorev.GorevNo, gorev).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Gorevlers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}