using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDAC_Maersk.Models;


namespace DDAC_Maersk.Controllers
{
    
        public class ScheduleController : Controller
        {
            private ApplicationDbContext _context;

            public ScheduleController()
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
                var schedule = _context.Schedules.ToList();

                return View(schedule);
            }

            //public ActionResult Create()
            //{
            //    return View();
            //}

            public ActionResult Create(Schedule schedule)
            {
                _context.Schedules.Add(schedule);

                _context.SaveChanges();


                var newScheduleInDb = _context.Schedules.Find(schedule.ScheduleID);

                return View("Details", newScheduleInDb);
            }

            public ActionResult Edit(int id)
            {
                var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == id);

                if (schedule == null)
                {
                    return HttpNotFound();
                }

                Schedule editSchedule = new Schedule();
                editSchedule.ScheduleID = schedule.ScheduleID;
                editSchedule.Destination = schedule.Destination;
                editSchedule.Origin = schedule.Origin;
                editSchedule.DepatureTime = schedule.DepatureTime;
                editSchedule.ArrivalTime = schedule.ArrivalTime;

                return View(editSchedule);
            }

            public ActionResult Update(Schedule sche)
            {
                var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == sche.ScheduleID);

                schedule.ScheduleID = sche.ScheduleID;
                schedule.Destination = sche.Destination;
                schedule.Origin = sche.Origin;
                schedule.DepatureTime = sche.DepatureTime;
                schedule.ArrivalTime = sche.ArrivalTime;

                _context.SaveChanges();

                var scheList = _context.Schedules.ToList();

                return View("Index", scheList);
            }

            public ActionResult Delete()
            {
                return View();
            }

            public ActionResult Details(int id)
            {
                var schedule = _context.Schedules.Find(id);

                return View(schedule);
            }
        }
    }