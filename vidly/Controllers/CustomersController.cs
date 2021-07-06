using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vidly.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = GetCustomers();

            var customer = customers.SingleOrDefault(m => m.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        // Hardcoded method for getting movies list
        private static IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Rick" },
                new Customer { Id = 2, Name = "Morty" }
            };
        }

    }

}
