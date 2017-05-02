using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cars.Context;
using Cars.Models;

namespace Cars.Controllers
{
    public class VechileMakeController : Controller
    {
        private VechileContext db = new VechileContext();

        // GET: VechileMake
        public ActionResult Index()
        {
            return View(db.VechileMakes.ToList());
        }

        // GET: VechileMake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechileMake vechileMake = db.VechileMakes.Find(id);
            if (vechileMake == null)
            {
                return HttpNotFound();
            }
            return View(vechileMake);
        }

        // GET: VechileMake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VechileMake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")] VechileMake vechileMake)
        {
            if (ModelState.IsValid)
            {
                db.VechileMakes.Add(vechileMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vechileMake);
        }

        // GET: VechileMake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechileMake vechileMake = db.VechileMakes.Find(id);
            if (vechileMake == null)
            {
                return HttpNotFound();
            }
            return View(vechileMake);
        }

        // POST: VechileMake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VechileMake vechileMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vechileMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vechileMake);
        }

        // GET: VechileMake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechileMake vechileMake = db.VechileMakes.Find(id);
            if (vechileMake == null)
            {
                return HttpNotFound();
            }
            return View(vechileMake);
        }

        // POST: VechileMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VechileMake vechileMake = db.VechileMakes.Find(id);
            db.VechileMakes.Remove(vechileMake);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
