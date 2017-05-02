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
    public class VechileModelController : Controller
    {
        private VechileContext db = new VechileContext();

        // GET: VechileModel
        public ActionResult Index()
        {
            var vechileModels = db.VechileModels.Include(v => v.VechileMake);
            return View(vechileModels.ToList());
        }

        // GET: VechileModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechileModel vechileModel = db.VechileModels.Find(id);
            if (vechileModel == null)
            {
                return HttpNotFound();
            }
            return View(vechileModel);
        }

        // GET: VechileModel/Create
        public ActionResult Create()
        {
            ViewBag.MakeId = new SelectList(db.VechileMakes, "Id", "Name");
            return View();
        }

        // POST: VechileModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv,MakeId")] VechileModel vechileModel)
        {
            if (ModelState.IsValid)
            {
                db.VechileModels.Add(vechileModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MakeId = new SelectList(db.VechileMakes, "Id", "Name", vechileModel.MakeId);
            return View(vechileModel);
        }

        // GET: VechileModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechileModel vechileModel = db.VechileModels.Find(id);
            if (vechileModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.MakeId = new SelectList(db.VechileMakes, "Id", "Name", vechileModel.MakeId);
            return View(vechileModel);
        }

        // POST: VechileModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv,MakeId")] VechileModel vechileModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vechileModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MakeId = new SelectList(db.VechileMakes, "Id", "Name", vechileModel.MakeId);
            return View(vechileModel);
        }

        // GET: VechileModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VechileModel vechileModel = db.VechileModels.Find(id);
            if (vechileModel == null)
            {
                return HttpNotFound();
            }
            return View(vechileModel);
        }

        // POST: VechileModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VechileModel vechileModel = db.VechileModels.Find(id);
            db.VechileModels.Remove(vechileModel);
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
