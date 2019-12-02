using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Data;
using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/Features
        public ActionResult Index()
        {
            return View(db.FeatureRepository.GetAll());
        }

        // GET: Admin/Features/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = db.FeatureRepository.GetById(id.Value);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // GET: Admin/Features/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Features/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeatureID,FeatureTitle")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                db.FeatureRepository.Insert(feature);
                db.Commit();
                return RedirectToAction("Index");
            }

            return View(feature);
        }

        // GET: Admin/Features/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = db.FeatureRepository.GetById(id.Value);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // POST: Admin/Features/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeatureID,FeatureTitle")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                db.FeatureRepository.Update(feature);
                db.Commit();
                return RedirectToAction("Index");
            }
            return View(feature);
        }

        // GET: Admin/Features/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = db.FeatureRepository.GetById(id.Value);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // POST: Admin/Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feature feature = db.FeatureRepository.GetById(id);
            db.FeatureRepository.Delete(feature);
            db.Commit();
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
