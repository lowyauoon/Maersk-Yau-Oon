using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDAC_Maersk.Models;

namespace DDAC_Maersk.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
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

        // GET: Schedules
        public ActionResult Index()
        {
            var customer = _context.Customers.ToList();

            return View(customer);
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}

        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();


            var newCustomerIndb = _context.Customers.Find(customer.CustomerID);

            return View("Details", newCustomerIndb);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.CustomerID == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            Customer editCustomer = new Customer();
            editCustomer.CustomerID = customer.CustomerID;
            editCustomer.ContactNumber = customer.ContactNumber;
            editCustomer.Email = customer.Email;
            editCustomer.Name = customer.Name;
            
            return View(editCustomer);
        }

        public ActionResult Update(Customer cust)
        {
            var customer = _context.Customers.SingleOrDefault(s => s.CustomerID == cust.CustomerID);

            customer.CustomerID = cust.CustomerID;
            customer.Email = cust.Email;
            customer.ContactNumber = cust.ContactNumber;
            customer.Name = cust.Name;
           

            _context.SaveChanges();

            var custList = _context.Customers.ToList();

            return View("Index", custList);
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var schedule = _context.Customers.Find(id);

            return View(schedule);
        }
    }
}