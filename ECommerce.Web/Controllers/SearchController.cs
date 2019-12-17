using ECommerce.Data;
using ECommerce.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.DomainModel;

namespace MyEshop.Controllers
{
    public class SearchController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        public ActionResult Index(string q)
        {
            List<Product> list = new List<Product>();

            list.AddRange(db.TagRepository.Search(q));
            list.AddRange(db.ProductRepository.Search(q));

            ViewBag.search = q;
            return View(list.Distinct());
        }
    }
}