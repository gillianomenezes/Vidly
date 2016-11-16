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
        private List<Customer> Customers = new List<Customer>
            {
                new Customer() { Name = "John Smith", Id = 1 },
                new Customer() { Name = "Mary Williams", Id = 2}
            };

        // GET: Customers
        public ActionResult Index()
        {

            CustomersViewModel customersViewModel = new CustomersViewModel()
            {
                Customers = this.Customers
            };

            return View(customersViewModel);
        }

        public ActionResult Details(int id)
        {
            if (Customers.Exists(x => x.Id == id))
            {
                Customer customer = Customers.First(x => x.Id == id);
                return View(Customers.First(x => x.Id == id));
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}