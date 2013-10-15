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
    public class PrefMethLineController : Controller
    {
        private PGDatabase db = new PGDatabase();

        //
        // GET: /PrefMethLine/

        public ActionResult Index()
        {
            var prefmethlines = db.PrefMethLines.Include(p => p.PreferredMethod);
            return View(prefmethlines.ToList());
        }

        //
        // GET: /PrefMethLine/Details/5

        public ActionResult Details(string id = null)
        {
            PrefMethLine prefmethline = db.PrefMethLines.Find(id);
            if (prefmethline == null)
            {
                return HttpNotFound();
            }
            return View(prefmethline);
        }

        //
        // GET: /PrefMethLine/Create

        public ActionResult Create()
        {
            ViewBag.prefMethID = new SelectList(db.PreferredMethods, "prefMethID", "whID");
            return View();
        }

        //
        // POST: /PrefMethLine/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrefMethLine prefmethline)
        {
            if (ModelState.IsValid)
            {
                db.PrefMethLines.Add(prefmethline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.prefMethID = new SelectList(db.PreferredMethods, "prefMethID", "whID", prefmethline.prefMethID);
            return View(prefmethline);
        }

        //
        // GET: /PrefMethLine/Edit/5

        public ActionResult Edit(string id = null)
        {
            PrefMethLine prefmethline = db.PrefMethLines.Find(id);
            if (prefmethline == null)
            {
                return HttpNotFound();
            }
            ViewBag.prefMethID = new SelectList(db.PreferredMethods, "prefMethID", "whID", prefmethline.prefMethID);
            return View(prefmethline);
        }

        //
        // POST: /PrefMethLine/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PrefMethLine prefmethline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prefmethline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.prefMethID = new SelectList(db.PreferredMethods, "prefMethID", "whID", prefmethline.prefMethID);
            return View(prefmethline);
        }

        //
        // GET: /PrefMethLine/Delete/5

        public ActionResult Delete(string id = null)
        {
            PrefMethLine prefmethline = db.PrefMethLines.Find(id);
            if (prefmethline == null)
            {
                return HttpNotFound();
            }
            return View(prefmethline);
        }

        //
        // POST: /PrefMethLine/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PrefMethLine prefmethline = db.PrefMethLines.Find(id);
            db.PrefMethLines.Remove(prefmethline);
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