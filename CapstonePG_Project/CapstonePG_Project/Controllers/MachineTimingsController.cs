using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstonePG_Project.Models;

namespace CapstonePG_Project.Controllers
{
    public class MachineTimingsController : Controller
    {
        private PGDatabase db = new PGDatabase();

        //
        // GET: /MachineTimings/

        public ActionResult Index()
        {
            var machinetimings = db.MachineTimings.Include(m => m.Warehouse);
            return View(machinetimings.ToList());
        }

        //
        // GET: /MachineTimings/Details/5

        public ActionResult Details(string id = null)
        {
            MachineTiming machinetiming = db.MachineTimings.Find(id);
            if (machinetiming == null)
            {
                return HttpNotFound();
            }
            return View(machinetiming);
        }

        //
        // GET: /MachineTimings/Create

        public ActionResult Create()
        {
            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName");
            return View();
        }

        //
        // POST: /MachineTimings/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MachineTiming machinetiming)
        {
            if (ModelState.IsValid)
            {
                db.MachineTimings.Add(machinetiming);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", machinetiming.whID);
            return View(machinetiming);
        }

        //
        // GET: /MachineTimings/Edit/5

        public ActionResult Edit(string id = null)
        {
            MachineTiming machinetiming = db.MachineTimings.Find(id);
            if (machinetiming == null)
            {
                return HttpNotFound();
            }
            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", machinetiming.whID);
            return View(machinetiming);
        }

        //
        // POST: /MachineTimings/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MachineTiming machinetiming)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machinetiming).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", machinetiming.whID);
            return View(machinetiming);
        }

        //
        // GET: /MachineTimings/Delete/5

        public ActionResult Delete(string id = null)
        {
            MachineTiming machinetiming = db.MachineTimings.Find(id);
            if (machinetiming == null)
            {
                return HttpNotFound();
            }
            return View(machinetiming);
        }

        //
        // POST: /MachineTimings/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MachineTiming machinetiming = db.MachineTimings.Find(id);
            db.MachineTimings.Remove(machinetiming);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}