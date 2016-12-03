using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerdb = _context.Customers.Single(c => c.Id == customer.Id);

                customerdb.BirthDate = customer.BirthDate;
                customerdb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerdb.MembershipType = customer.MembershipType;
                customerdb.MembershipTypeId = customer.MembershipTypeId;
                customerdb.Name = customer.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes;

            var CustomerFormViewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(CustomerFormViewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var customerForm = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", customerForm);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var customers = _context.Customers;

            return customers;
        }
    }
}