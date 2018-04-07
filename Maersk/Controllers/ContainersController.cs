using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maersk.Models;

namespace Maersk.Controllers
{
    public class ContainersController : Controller
    {
        private ApplicationDbContext _context;

        public ContainersController()
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

        // GET: Containers
        public ActionResult Index()
        {
            var container = _context.Containers.ToList();

            return View(container);
        }

        public ActionResult Create(Container container)
        {
            _context.Containers.Add(container);

            _context.SaveChanges();


            var newContainerInDb = _context.Containers.Find(container.ContainerID);

            return View("Details", newContainerInDb);
        }

        public ActionResult Delete(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Container con = _context.Containers.Find(id);
                if (con == null)
                {
                    return HttpNotFound();
                }

                return View(con);
            }
        }

        // POST: Container/Delete/

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Container container = _context.Containers.Find(id);
            _context.Containers.Remove(container);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var container = _context.Containers.Find(id);

            return View(container);
        }
    }
}