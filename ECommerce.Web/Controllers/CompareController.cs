using ECommerce.Data;
using ECommerce.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.DomainModel;

namespace ECommerce.Web.Controllers
{
    public class CompareController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        // GET: Compare
        public ActionResult Index()
        {
         
            return View();
        }


        public int AddToCompare(int id)
        {
            List<CompareItem> list = new List<CompareItem>();

            if (Session["Compare"] != null)
            {
                list = Session["Compare"] as List<CompareItem>;
            }

            if (!list.Any(p => p.ProductID == id))
            {
                var product = db.ProductRepository.GetAll().Where(p => p.ProductId == id).Select(p => new { p.ProductTitle, p.ImageName }).Single();
                list.Add(new CompareItem()
                {
                    ProductID = id,
                    Title = product.ProductTitle,
                    ImageName = product.ImageName
                });
            }
            Session["Compare"] = list;

            return list.Count;
        }
        public int CountCompate()
        {
            List<CompareItem> list = new List<CompareItem>();

            if (Session["Compare"] != null)
            {
                list = Session["Compare"] as List<CompareItem>;
            }
          return  list.Count;
        }

        public ActionResult ListCompare()
        {
            List<CompareItem> list = new List<CompareItem>();

            if (Session["Compare"] != null)
            {
                list = Session["Compare"] as List<CompareItem>;
            }
            List<Feature> features = new List<Feature>();
            List<Product_Feature> productFeatures = new List<Product_Feature>();
            foreach (var item in list)
            {
                features.AddRange(db.Product_FeatureRepository.GetAll().Where(p => p.ProductID == item.ProductID).Select(f => f.Features).ToList());

                productFeatures.AddRange(db.Product_FeatureRepository.GetAll().Where(p => p.ProductID == item.ProductID).ToList());
            }
            ViewBag.features = features.Distinct().ToList();
            ViewBag.productFeatures = productFeatures;
            return PartialView(list);
        }

        public ActionResult DeleteFromCompare(int id)
        {
            List<CompareItem> list = new List<CompareItem>();

            if (Session["Compare"] != null)
            {
                list = Session["Compare"] as List<CompareItem>;
                int index = list.FindIndex(p => p.ProductID == id);
                list.RemoveAt(index);
                Session["Compare"] = list;
            }
            return  RedirectToAction("ListCompare");

        }
    }
}