using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maersk.Models;

namespace Maersk.Controllers
{
    public class SchedulesController : Controller
    {
        private ApplicationDbContext _context;

        public SchedulesController()
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
            editSchedule.DepartureDateTime = schedule.DepartureDateTime;
            editSchedule.ArrivalDateTime = schedule.ArrivalDateTime;

            return View(editSchedule);
        }

        public ActionResult Update(Schedule sche)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.ScheduleID == sche.ScheduleID);

            schedule.ScheduleID = sche.ScheduleID;
            schedule.Destination = sche.Destination;
            schedule.Origin = sche.Origin;
            schedule.DepartureDateTime = sche.DepartureDateTime;
            schedule.ArrivalDateTime = sche.ArrivalDateTime;

            _context.SaveChanges();

            var scheList = _context.Schedules.ToList();

            return View("Index", scheList);
        }

        public ActionResult Delete(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Schedule sche = _context.Schedules.Find(id);
                if (sche == null)
                {
                    return HttpNotFound();
                }

                return View(sche);
            }
        }

        // POST: Schedule/Delete/

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Schedule s = _context.Schedules.Find(id);
            _context.Schedules.Remove(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var schedule = _context.Schedules.Find(id);

            return View(schedule);
        }
    }
}