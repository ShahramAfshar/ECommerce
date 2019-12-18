using ECommerce.Data;
using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();

        public ActionResult GetSingleProduct(int productId)
        {
            var product = db.ProductRepository.GetById(productId);
            ViewBag.ProductFeatures = product.Product_Features.Select(f => new ShowProductFeatureViewModel()
            {
                FeatureTitle = f.Features.FeatureTitle,
                Values = db.Product_FeatureRepository.GetAll().Where(fe => fe.FeatureID == f.FeatureID).Select(fe => fe.Value).ToList()
            }).ToList();
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult GetMaxSale()
        {
            var model = db.ProductRepository.GetMaxSale(0, 5);
            return PartialView(model);
        }
        public ActionResult GetMaxSaleForIndex()
        {
            var model = db.ProductRepository.GetMaxSale(0, 10);
            return PartialView(model);
        }

        public ActionResult GetLastAdd()
        {
            var model = db.ProductRepository.GetLastAdd(0, 5);
            return PartialView(model);
        }
        public ActionResult GetLastAddForIndex()
        {
            var model = db.ProductRepository.GetLastAdd(0, 10);
            return PartialView(model);
        }

        public ActionResult ProductWithCategory()
        {
            ViewBag.ProductGroup = db.ProductGroupRepository.GetHeadGroup();
            ViewBag.Product_ProductGroup = db.Product_ProductGroupRepository.GetAll();
            return PartialView();
        }

        public ActionResult GetProduct(int id)
        {


            var model = db.Product_ProductGroupRepository.GetProduct(id);
            return PartialView(model);
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(db.CommentRepository.GetForProduct(id));
        }

        public ActionResult CreateComment(int id)
        {
            return PartialView(new Comment()
            {
                ProductID = id
            });
        }

        [HttpPost]
        public ActionResult CreateComment(Comment  comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                db.CommentRepository.Insert(comment);
                db.Commit();

                return PartialView("ShowComments", db.CommentRepository.GetForProduct(comment.ProductID));

            }
            return PartialView(comment);
        }

        public ActionResult ProductRelative(int productId)
        {
           
            Product product = db.ProductRepository.GetById(productId);
            if (product !=null)
            {
                int productGroupId = product.Product_ProductGroups.Select(pg => pg.ProductGroupId).First();
             var res=  db.Product_ProductGroupRepository.GetProduct(productGroupId,10);
                return PartialView(res);
            }
       
          //  var res = db.ProductRepository.Relative(productId);
            return null;
        }
        public ActionResult GetproductByGroup(int productGroupId)
        {

            var res = db.Product_ProductGroupRepository.GetProduct(productGroupId);
            if (res!=null)
            {
                ViewBag.productGroupName = db.ProductGroupRepository.GetById(productGroupId).Title;
                return View(res);
            }
           return RedirectToAction("Index","Home");

           
        }
    }
}