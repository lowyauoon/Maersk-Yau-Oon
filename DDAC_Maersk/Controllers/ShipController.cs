using DDAC_Maersk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDAC_Maersk.Controllers
{
    public class ShipController : Controller
    {
        private ApplicationDbContext _context;

        public ShipController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Ship
        public ActionResult Index()
        {
            var ships = _context.Ships.ToList();

            return View(ships);
        }

        public ActionResult Create(Ship ships)
        {
            _context.Ships.Add(ships);

            _context.SaveChanges();

            var Ships = _context.Ships.ToList();

            return View("Index" , Ships);
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}