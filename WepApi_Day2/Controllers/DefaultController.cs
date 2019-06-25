using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WepApi_Day2.Models;

namespace WepApi_Day2.Controllers
{
    public class DefaultController : Controller
    {
        HttpClient client = new HttpClient();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {
            var res = client.GetAsync("https://localhost:44335/api/customers").Result;
            if(res.IsSuccessStatusCode==true)
            {
                return View(res.Content.ReadAsAsync<List<Customer>>().Result);
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddNewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewCustomer(Customer cus)
        {
            var res = client.PostAsJsonAsync("https://localhost:44335/api/customers",cus).Result;
            if (res.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}