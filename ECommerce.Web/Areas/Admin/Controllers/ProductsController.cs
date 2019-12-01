﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerce.Data;
using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(db.ProductRepository.GetAll());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductRepository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.Groups = db.ProductGroupRepository.GetAll();
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductTitle,ShortDescription,Text,Price,CreateDate,ImageName,CountSale")] Product product, List<int> selectedGroups, HttpPostedFileBase imageProduct, string tags)
        {

            if (ModelState.IsValid)
            {
                if (selectedGroups == null)
                {
                    ViewBag.ErrorSelectedGroup = true;
                    ViewBag.Groups = db.ProductGroupRepository.GetAll();
                    return View(product);
                }
                product.ImageName = "images.jpg";
                if (imageProduct != null && imageProduct.IsImage())
                {
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/ProductImages/" + product.ImageName),
                        Server.MapPath("/Images/ProductImages/Thumb/" + product.ImageName));
                }
                product.CreateDate = DateTime.Now;
                db.ProductRepository.Insert(product);

                foreach (int selectedGroup in selectedGroups)
                {
                    db.Product_ProductGroupRepository.Insert(new Product_ProductGroup()
                    {
                        ProductId = product.ProductId,
                        ProductGroupId = selectedGroup
                    });
                }

                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (string t in tag)
                    {
                        db.TagRepository.Insert(new Tag()
                        {
                            ProductId = product.ProductId,
                            Title = t.Trim()
                        });
                    }
                }
                db.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.Groups = db.ProductGroupRepository.GetAll();
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductRepository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.SelectedGroups = product.Product_ProductGroups.ToList();
            ViewBag.Groups = db.ProductGroupRepository.GetAll();
            ViewBag.Tags = string.Join(",", product.Tags.Select(t => t.Title).ToList());

            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductTitle,ShortDescription,Text,Price,CreateDate,ImageName,CountSale")] Product product,
             List<int> selectedGroups, HttpPostedFileBase imageProduct, string tags
            )
        {
            if (ModelState.IsValid)
            {
                if (imageProduct != null && imageProduct.IsImage())
                {
                    if (product.ImageName != "images.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/" + product.ImageName));
                        System.IO.File.Delete(Server.MapPath("/Images/ProductImages/Thumb/" + product.ImageName));
                    }

                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/ProductImages/" + product.ImageName),
                        Server.MapPath("/Images/ProductImages/Thumb/" + product.ImageName));
                }
             //   db.Entry(products).State = EntityState.Modified;


                db.TagRepository.GetMany(t => t.ProductId == product.ProductId).ToList().ForEach(t => db.TagRepository.Delete(t));


                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (string t in tag)
                    {
                        db.TagRepository.Insert(new Tag()
                        {
                            ProductId = product.ProductId,
                            Title = t.Trim()
                        });
                    }
                }


                db.Product_ProductGroupRepository.GetMany(g => g.ProductId == product.ProductId).ToList().ForEach(g => db.Product_ProductGroupRepository.Delete(g));

                if (selectedGroups != null && selectedGroups.Any())
                {
                    foreach (int selectedGroup in selectedGroups)
                    {
                        db.Product_ProductGroupRepository.Insert(new Product_ProductGroup()
                        {
                            ProductId = product.ProductId,
                            ProductGroupId = selectedGroup
                        });
                    }
                }

                db.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.SelectedGroups = selectedGroups;
            ViewBag.Groups = db.ProductGroupRepository.GetAll();
            ViewBag.Tags = tags;
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.ProductRepository.GetById(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.ProductRepository.GetById(id);
            db.ProductRepository.Delete(product);
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
