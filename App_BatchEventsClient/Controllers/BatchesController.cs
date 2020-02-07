
using App_BatchEventsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace App_BatchEventsClient.Controllers
{
    public class BatchesController : Controller
    {

        readonly HttpClient client = new HttpClient();
        public BatchesController()
        {
            client.BaseAddress = new Uri("https://brmapi.azurewebsites.net/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public ActionResult index()
        {
            return View(List());
        }

        public JsonResult List()
        {
            IEnumerable<BatchVM> batches = null;
            var responTask = client.GetAsync("Batches");
            responTask.Wait();
            var result = responTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<IList<BatchVM>>();
                readTask.Wait();
                batches = readTask.Result;


            }
            else
            {
                batches = Enumerable.Empty<BatchVM>();
                ModelState.AddModelError(string.Empty, "404 Not Found");
            }
            //return new CustomJsonResult { Data = new { data = batches.ToList() } };
            return Json(new { data = batches }, JsonRequestBehavior.AllowGet);
        }

    }
}