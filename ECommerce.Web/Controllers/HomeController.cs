﻿using ECommerce.Data;
using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Slider()
        {
            return PartialView("_PartialSlider",db.SliderRepository.GetValid());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                contactUs.CreateDate = DateTime.Now;
                db.ContactUsRepository.Insert(contactUs);
                db.Commit();

                return RedirectToAction("Index");
            }
            return View(contactUs);
           
        }

        public ActionResult Category()
        {
            ViewBag.ProductGroup = db.ProductGroupRepository.GetAll();
            return PartialView("_PartialCategory");
        }
    }
}