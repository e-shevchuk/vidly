using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [SuppressMessage("ReSharper", "HeapView.ObjectAllocation.Evident")]
    [SuppressMessage("ReSharper", "HeapView.DelegateAllocation")]
    public class CustomersController : Controller
    {
        // GET
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer() {Id = 0, Name = "John Smith"},
                new Customer() {Id = 1, Name = "Mary Williams"}
            };

            var viewModel = new CustomersViewModel()
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer() {Id = 0, Name = "John Smith"},
                new Customer() {Id = 1, Name = "Mary Williams"}
            };

            var customer = customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Redirect("~/Errors/Error404");
            
            return View(customer);
        }
    }
}