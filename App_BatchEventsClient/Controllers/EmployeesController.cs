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
    public class EmployeesController : Controller
    {
       readonly HttpClient client = new HttpClient();
        public EmployeesController()
        {
            client.BaseAddress = new Uri("https://brmapi.azurewebsites.net/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View(List());
        }
        public JsonResult List()
        {
            IEnumerable<EmployeeVM> employees = null;
            var responTask = client.GetAsync("Employees");
            responTask.Wait();
            var result = responTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<IList<EmployeeVM>>();
                readTask.Wait();
                employees = readTask.Result;


            }
            else
            {
                employees = Enumerable.Empty<EmployeeVM>();
                ModelState.AddModelError(string.Empty, "404 Not Found");
            }
            //return new CustomJsonResult { Data = new { data = batches.ToList() } };
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }
    }
}