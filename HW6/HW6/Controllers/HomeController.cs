using HW6.Models;
using HW6.Models.VM;
using System;
using System.Linq;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private EFWideWorldImportersContext database = new EFWideWorldImportersContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(String namePart)
        {
            namePart = Request.QueryString["search"];

            if (namePart == null)
            {
                ViewBag.message = false;
                return View();
            }
            else
            {
                ViewBag.message = true;
                var peopleMatch = database.People.Where(p => p.FullName.Contains(namePart));
                return View(peopleMatch.ToList());
            }
        }

        public ActionResult Information(int? id)
        {
            ViewModel vm = new ViewModel();
            vm.Person = database.People.Find(id);
            if (vm.Person.Customers2.Count() > 0)
            {
                ViewBag.customer2 = true;
                int customerID = vm.Person.Customers2.First().CustomerID;
                vm.Customer = database.Customers.Find(customerID);
                ViewBag.grosssales = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(i => i.InvoiceLines).Sum(i => i.ExtendedPrice);
                ViewBag.grossprofit = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(i => i.InvoiceLines).Sum(i => i.LineProfit);
                vm.InvoiceLine = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(i => i.InvoiceLines).OrderByDescending(i => i.LineProfit).Take(10).ToList();
            }
            else
            {
                ViewBag.customer2 = false;
            }
            return View(vm);
        }
    }
}