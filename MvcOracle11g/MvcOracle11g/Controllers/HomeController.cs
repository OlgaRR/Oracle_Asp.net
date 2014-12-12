using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOracle11g.Models;

namespace MvcOracle11g.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.EXAMPLE.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(decimal id = 0)
        {
            EXAMPLE example = db.EXAMPLE.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EXAMPLE example)
        {
            if (ModelState.IsValid)
            {
                db.EXAMPLE.Add(example);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(example);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(decimal id = 0)
        {
            EXAMPLE example = db.EXAMPLE.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EXAMPLE example)
        {
            if (ModelState.IsValid)
            {
                db.Entry(example).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(example);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(decimal id = 0)
        {
            EXAMPLE example = db.EXAMPLE.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            EXAMPLE example = db.EXAMPLE.Find(id);
            db.EXAMPLE.Remove(example);
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