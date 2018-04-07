using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maersk.Models;

namespace Maersk.Controllers
{
    public class ShipsController : Controller
    {
        private ApplicationDbContext _context;

        public ShipsController()
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

        // GET: Ships
        public ActionResult Index()
        {
            var ship = _context.Ships.ToList();

            return View(ship);
        }

        public ActionResult Create(Ship ship)
        {
            _context.Ships.Add(ship);

            _context.SaveChanges();


            var newShipInDb = _context.Ships.Find(ship.ShipID);

            return View("Details", newShipInDb);
        }

        public ActionResult Edit(int id)
        {
            var ship = _context.Ships.SingleOrDefault(s => s.ShipID == id);

            if (ship == null)
            {
                return HttpNotFound();
            }

            Ship editShip = new Ship();
            editShip.ShipID = ship.ShipID;
            editShip.ShipContainerSpace = ship.ShipContainerSpace;
            editShip.ShipName = ship.ShipName;

            return View(editShip);
        }

        public ActionResult Update(Ship ship)
        {
            var ship2 = _context.Ships.SingleOrDefault(s => s.ShipID == ship.ShipID);

            ship2.ShipID = ship.ShipID;
            ship2.ShipContainerSpace = ship.ShipContainerSpace;
            ship2.ShipName = ship.ShipName;

            _context.SaveChanges();

            var shipList = _context.Ships.ToList();

            return View("Index", shipList);
        }

        public ActionResult Delete(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Ship ship = _context.Ships.Find(id);
                if (ship == null)
                {
                    return HttpNotFound();
                }

                return View(ship);
            }
        }

        // POST: Ship/Delete/

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Ship s = _context.Ships.Find(id);
            _context.Ships.Remove(s);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var ship = _context.Ships.Find(id);

            return View(ship);
        }
    }
}