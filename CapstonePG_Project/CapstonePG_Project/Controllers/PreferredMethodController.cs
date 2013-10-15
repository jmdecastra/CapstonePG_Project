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
    public class PreferredMethodController : Controller
    {
        private PGDatabase db = new PGDatabase();

        //
        // GET: /PreferredMethod/

        public ActionResult Index()
        {
            var preferredmethods = db.PreferredMethods.Include(p => p.Warehouse);
            return View(preferredmethods.ToList());
        }

        //
        // GET: /PreferredMethod/Details/5

        public ActionResult Details(string id = null)
        {
            PreferredMethod preferredmethod = db.PreferredMethods.Find(id);
            if (preferredmethod == null)
            {
                return HttpNotFound();
            }
            return View(preferredmethod);
        }

        //
        // GET: /PreferredMethod/Create

        public ActionResult Create()
        {

            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName");

            string uniqueID = GenerateId();
            int uniqueIDint;

            bool result = Int32.TryParse(uniqueID, out uniqueIDint);
            if (true == result)
                ViewBag.uniqueID = uniqueIDint;
            else
                ViewBag.uniqueID = 00000000;

            // ViewBag.uniqueID = Convert.ToInt32(uniqueID);
            //  int.TryParse(ViewBag.uniqueID, out uniqueID);

            return View();
        }

        //
        // POST: /PreferredMethod/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PreferredMethod preferredmethod)
        {
            if (ModelState.IsValid)
            {
                db.PreferredMethods.Add(preferredmethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", preferredmethod.whID);
            return View(preferredmethod);
        }

        //
        // GET: /PreferredMethod/Edit/5

        public ActionResult Edit(string id = null)
        {
            PreferredMethod preferredmethod = db.PreferredMethods.Find(id);
            if (preferredmethod == null)
            {
                return HttpNotFound();
            }
            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", preferredmethod.whID);
            return View(preferredmethod);
        }

        //
        // POST: /PreferredMethod/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PreferredMethod preferredmethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preferredmethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.whID = new SelectList(db.Warehouses, "whID", "whName", preferredmethod.whID);
            return View(preferredmethod);
        }

        //
        // GET: /PreferredMethod/Delete/5

        public ActionResult Delete(string id = null)
        {
            PreferredMethod preferredmethod = db.PreferredMethods.Find(id);
            if (preferredmethod == null)
            {
                return HttpNotFound();
            }
            return View(preferredmethod);
        }

        //
        // POST: /PreferredMethod/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PreferredMethod preferredmethod = db.PreferredMethods.Find(id);
            db.PreferredMethods.Remove(preferredmethod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private string GenerateId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}