using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maersk.Models;

namespace Maersk.Controllers
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

        public ActionResult New()
        {
            return View();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customer = _context.Customers.ToList();

            return View(customer);
        }

        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();


            var newCustomerInDb = _context.Customers.Find(customer.CustomerID);

            return View("Details", newCustomerInDb);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.CustomerID == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            Customer editCustomer = new Customer();
            editCustomer.Name = customer.Name;
            editCustomer.Email = customer.Email;
            editCustomer.ContactNo = customer.ContactNo;
            editCustomer.CustomerID = customer.CustomerID;

            return View(editCustomer);
        }

        public ActionResult Update(Customer cus)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerID == cus.CustomerID);

            customer.Name = cus.Name;
            customer.Email = cus.Email;
            customer.ContactNo = cus.ContactNo;

            _context.SaveChanges();

            var cusList = _context.Customers.ToList();

            return View("Index", cusList);
        }

        public ActionResult Delete(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Customer cus = _context.Customers.Find(id);
                if (cus == null)
                {
                    return HttpNotFound();
                }

                return View(cus);
            }
        }

        // POST: Customer/Delete/

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Customer cu = _context.Customers.Find(id);
            _context.Customers.Remove(cu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Find(id);

            return View(customer);
        }
    }
}