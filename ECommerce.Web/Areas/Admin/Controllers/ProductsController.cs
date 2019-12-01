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
                    products.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/ProductImages/" + products.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/ProductImages/" + products.ImageName),
                        Server.MapPath("/Images/ProductImages/Thumb/" + products.ImageName));
                }
                products.CreateDate = DateTime.Now;
                db.Products.Add(products);

                foreach (int selectedGroup in selectedGroups)
                {
                    db.Prodct_Selected_Groups.Add(new Prodct_Selected_Groups()
                    {
                        ProductID = products.ProductID,
                        GroupID = selectedGroup
                    });
                }

                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (string t in tag)
                    {
                        db.Product_Tags.Add(new Product_Tags()
                        {
                            ProductID = products.ProductID,
                            Tag = t.Trim()
                        });
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Groups = db.Product_Groups.ToList();
            return View(products);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductTitle,ShortDescription,Text,Price,CreateDate,ImageName,CountSale")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
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
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
