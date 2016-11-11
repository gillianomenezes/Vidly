using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            var customers = new List<Customer>
            {
                new Customer() { Name = "customer 1", Id = 1 },
                new Customer() { Name = "customer 2", Id = 2}
            };

            CustomersViewModel customersViewModel = new CustomersViewModel()
            {
                Customers = customers
            };

            return View(customersViewModel);
        }

        public ActionResult Details(int id)
        {
            return Content("id=" + id);            
        }
    }
}