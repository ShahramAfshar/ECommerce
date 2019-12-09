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
    public class ProductGroupsController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult ListGroup()
        {

            return PartialView(db.ProductGroupRepository.GetHeadGroup());
        }

        // GET: Admin/ProductGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productGroup = db.ProductGroupRepository.GetById(id.Value);
            if (productGroup == null)
            {
                return HttpNotFound();
            }
            return View(productGroup);
        }


        public ActionResult Create(int? id)
        {


            ProductGroup productGroup = new ProductGroup() { ParentId = id };
            return PartialView(productGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductGroupId,Title,ParentId")] ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {

                db.ProductGroupRepository.Insert(productGroup);
                db.Commit();

                return PartialView("ListGroup", db.ProductGroupRepository.GetHeadGroup());
            }

            return PartialView();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductGroup productGroup = db.ProductGroupRepository.GetById(id.Value);
            if (productGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(productGroup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductGroupId,Title,ParentId")] ProductGroup productGroup)
        {
            if (ModelState.IsValid)
            {
                db.ProductGroupRepository.Update(productGroup);
                db.Commit();

                return PartialView("ListGroup", db.ProductGroupRepository.GetHeadGroup());
            }
            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Delete/5
        public void Delete(int id)
        {
            ProductGroup productGroupHeader = db.ProductGroupRepository.GetById(id);
            if (productGroupHeader.ListProductGroup.Any())
            {
                foreach (var itemSub in db.ProductGroupRepository.GetSubGroupForOneHeader(id))
                {
                    db.ProductGroupRepository.Delete(itemSub);
                }
            }

            db.ProductGroupRepository.Delete(productGroupHeader);
            db.Commit();

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
