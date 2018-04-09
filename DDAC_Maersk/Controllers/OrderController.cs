using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDAC_Maersk.Models;
using DDAC_Maersk.ViewModel;
using System.Data.Entity;

namespace DDAC_Maersk.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _context;

        public OrderController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Bookings
        public ActionResult Details()
        {
            return View();
        }

        //Select schedule in booking view
        public ActionResult SelectSchedule()
        {
            var schedule = _context.Schedules.ToList();
            return View(schedule);
        }

        //Select Ship in booking view
        public ActionResult SelectShip(int Scheduleid)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == Scheduleid);
            var shipList = _context.Ships.ToList();

            var viewModel = new SSCViewModel
            {
                Schedule = schedule,
                Ships = shipList
            };

            return View(viewModel);
        }

        //Select Customer in booking view
        public ActionResult SelectCustomer(int Scheduleid, int Shipid)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == Scheduleid);
            var ship = _context.Ships.SingleOrDefault(s => s.ShipId == Shipid);
            var CustomerList = _context.Customers.ToList();

            var viewModel = new SSCViewModel
            {
                Schedule = schedule,
                Ship = ship,
                Customers = CustomerList

            };

            return View(viewModel);
        }


        //Select Container in booking view
        public ActionResult SelectContainer(int Shipid, int Scheduleid, int Customerid)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == Scheduleid);
            var Ship = _context.Ships.SingleOrDefault(s => s.ShipId == Shipid);
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerID == Customerid);
            //var ContainerList = _context.Containers.ToList();

            var viewModel = new SSCViewModel
            {
                Schedule = schedule,
                Ship = Ship,
                Customer = customer
                // Containers = ContainerList

            };

            return View(viewModel);
        }

        public ActionResult CreateBooking(SSCViewModel sscvm)
        {
            var tempShipID = sscvm.Ship.ShipId;
            var newContainerSpace = sscvm.Container.WeightofContainer;

            var tempContainerSpace = _context.Ships.Single(s => s.ShipId == tempShipID).ShipContainerNumber;

            if (tempContainerSpace - newContainerSpace < 0)
            {
                ViewBag.Error = "The container space is exceeded the ship's container space.";

                var oldSchedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == sscvm.Schedule.ScheduleID);
                var oldShip = _context.Ships.SingleOrDefault(s => s.ShipId == sscvm.Ship.ShipId);
                var oldCustomer = _context.Customers.SingleOrDefault(c => c.CustomerID == sscvm.Customer.CustomerID);

                var viewModel = new SSCViewModel
                {
                    Schedule = oldSchedule,
                    Ship = oldShip,
                    Customer = oldCustomer
                };

                return View("SelectContainer", viewModel);
            }

            var ship = _context.Ships.Single(s => s.ShipId == sscvm.Ship.ShipId);
            ship.ShipContainerNumber = Convert.ToInt32(tempContainerSpace - newContainerSpace);

            var order = new Order()
            {
                ScheduleID = sscvm.Schedule.ScheduleID,
                ShipId = sscvm.Ship.ShipId,
                CustomerID = sscvm.Customer.CustomerID,
                OrderAgent = "Jake lol"
            };

            //_context.Bookings.Add(booking);
            //_context.SaveChanges();

            //var test = _context.Bookings.SingleOrDefault(b => b.CustomerID == sscvm.Customer.CustomerID);

            var container = new Container()
            {
                ContainerID = sscvm.Container.ContainerID,
                TypeOfContainer = sscvm.Container.TypeOfContainer,
                WeightofContainer = sscvm.Container.WeightofContainer,

                OrderID = sscvm.Order.OrderID
            };

            _context.Orders.Add(order);
            _context.Containers.Add(container);
            _context.SaveChanges();

            //var orderList = _context.Containers.Include(o => o.Booking).ToList();


            var orderList = _context.Containers
                .Include(o => o.Order.Schedule)
                .Include(o => o.Order.Customer)
                .Include(o => o.Order.Ship)
                .Include(o => o.Order)
                .ToList();


            //var containerList = _context.Containers
            //    .Include(c => c.Booking)
            //    .Include(c => c.ContainerID)
            //    .Include(c => c.ContainerType)
            //    .Include(c => c.ContainerWeight)
            //    .ToList();

            //return View(orderList);
            return View("ViewBooking", orderList);
        }

        public ActionResult ViewBooking()
        {
            //var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == Scheduleid);
            //var ship = _context.Ships.SingleOrDefault(s => s.ShipID == Shipid);
            //var customer = _context.Customers.SingleOrDefault(c => c.CustomerID == Customerid);
            var container = _context.Containers
                .Include(c => c.Order)
                .Include(c => c.Order.Schedule)
                .Include(c => c.Order.Customer)
                .Include(c => c.Order.Ship).ToList();
            //.SingleOrDefault(c => c.ContainerID == Containerid);

            //var viewModel = new ScheduleShipCustomerViewModel()
            //{
            //    Schedule = schedule,
            //    Ship = ship,
            //    Customer = customer,
            //    Container = container
            //};   
            //var orderList = _context.Bookings
            //    .Include(o => o.Schedule)
            //    .Include(o => o.Customer)
            //    .Include(o => o.Ship)
            //    .ToList();


            //var book = _context.Containers.Include(b => b.)

            return View(container);
        }
    }
}