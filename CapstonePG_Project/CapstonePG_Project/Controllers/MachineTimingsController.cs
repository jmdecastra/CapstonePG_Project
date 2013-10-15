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
    public class MachineTimingController : Controller
    {
        private PGDatabase db = new PGDatabase();

        //
        // GET: /MachineTiming/

        public ActionResult Index()
        {
            var MachineTiming = db.MachineTiming.Include(m => m.Warehouse);
            return View(MachineTiming.ToList());
        }

        //
        // GET: /MachineTiming/Details/5

        public ActionResult Details(string id = null)
        {
            MachineTiming machinetiming = db.MachineTiming.Find(id);
            if (machinetiming == null)
            {
                return HttpNotFound();
            }
            return View(machinetiming);
        }

        //
        // GET: /MachineTiming/Create

        public ActionResult Create()
        {
            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName");
            return View();
        }

        //
        // POST: /MachineTiming/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MachineTiming machinetiming)
        {
            if (ModelState.IsValid)
            {
                db.MachineTiming.Add(machinetiming);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", machinetiming.whID);
            return View(machinetiming);
        }

        //
        // GET: /MachineTiming/Edit/5

        public ActionResult Edit(string id = null)
        {
            MachineTiming machinetiming = db.MachineTiming.Find(id);
            if (machinetiming == null)
            {
                return HttpNotFound();
            }
            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", machinetiming.whID);
            return View(machinetiming);
        }

        //
        // POST: /MachineTiming/Edit/5

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
        // GET: /MachineTiming/Delete/5

        public ActionResult Delete(string id = null)
        {
            MachineTiming machinetiming = db.MachineTiming.Find(id);
            if (machinetiming == null)
            {
                return HttpNotFound();
            }
            return View(machinetiming);
        }

        //
        // POST: /MachineTiming/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MachineTiming machinetiming = db.MachineTiming.Find(id);
            db.MachineTiming.Remove(machinetiming);
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