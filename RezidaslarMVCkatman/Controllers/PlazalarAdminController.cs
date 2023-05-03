using RezidaslarMVCkatman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace RezidaslarMVCkatman.Controllers
{
    public class PlazalarAdminController : Controller
    {
        // GET: PlazalarAdmin
        public ActionResult Index()
        {
            IEnumerable<mvcPlazalarModel> listele;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Plazalars").Result; // apiye bağlanacak alan

            listele = response.Content.ReadAsAsync<IEnumerable<mvcPlazalarModel>>().Result; //verileri alıyor 
            return View(listele); // view ee aktar.
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcPlazalarModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Plazalars/" +id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPlazalarModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(mvcPlazalarModel plaza)
        {
            if (plaza.plazaNo ==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Plazalars", plaza).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Plazalars/" + plaza.plazaNo, plaza).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Plazalars/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}