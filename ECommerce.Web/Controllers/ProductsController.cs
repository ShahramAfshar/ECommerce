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
                Values = db.Product_FeatureRepository.GetAll().Where(fe => fe.FeatureID == f.FeatureID).Distinct().Select(fe => fe.Value).ToList()
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
    }
}