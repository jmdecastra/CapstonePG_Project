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
    public class WarehouseController : Controller
    {
        private PGDatabase db = new PGDatabase();

        //
        // GET: /Warehouse/

        public ActionResult Index()
        {
            return View(db.Warehouses.ToList());
        }

        //
        // GET: /Warehouse/Details/5

        public ActionResult Details(string id = null)
        {
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        //
        // GET: /Warehouse/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Warehouse/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Warehouses.Add(warehouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        //
        // GET: /Warehouse/Edit/5

        public ActionResult Edit(string id = null)
        {
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        //
        // POST: /Warehouse/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouse);
        }

        //
        // GET: /Warehouse/Delete/5

        public ActionResult Delete(string id = null)
        {
            Warehouse warehouse = db.Warehouses.Find(id);
            if (warehouse == null)
            {
                return HttpNotFound();
            }
            return View(warehouse);
        }

        //
        // POST: /Warehouse/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Warehouse warehouse = db.Warehouses.Find(id);
            db.Warehouses.Remove(warehouse);
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