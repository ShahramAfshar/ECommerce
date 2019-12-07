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
    public class WishController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        public int Get()
        {
            List<ShopCartItem> list = new List<ShopCartItem>();
            // var sessions = HttpContext.Current.Session;
            if (Session["Wish"] != null)
            {
                list = Session["Wish"] as List<ShopCartItem>;
            }

            return list.Sum(l => l.Count);
        }

        // GET: api/Shop/5
        public int AddToWish(int id)
        {
            List<ShopCartItem> list = new List<ShopCartItem>();
            //var sessions = HttpContext.Current.Session;
            if (Session["Wish"] != null)
            {
                list = Session["Wish"] as List<ShopCartItem>;
            }
            if (list.Any(p => p.ProductID == id))
            {
                int index = list.FindIndex(p => p.ProductID == id);
                list[index].Count += 1;
            }
            else
            {
                list.Add(new ShopCartItem()
                {
                    ProductID = id,
                    Count = 1
                });
            }

            Session["Wish"] = list;
            return Get();
        }

        public ActionResult DeleteWish (int id)
        {

           List<ShopCartItem> listShop = (List<ShopCartItem>)Session["Wish"];

            int index = listShop.FindIndex(p => p.ProductID == id);

             listShop.RemoveAt(index);
            Session["Wish"] = listShop;

            return RedirectToAction("ShowWish");
        }

        public ActionResult ShowWish()
        {
            List<ShopCartItemViewModel> list = new List<ShopCartItemViewModel>();

            if (Session["Wish"] != null)
            {
                List<ShopCartItem> listShop = (List<ShopCartItem>)Session["Wish"];

                foreach (var item in listShop)
                {

                    var product = db.ProductRepository.GetById(item.ProductID);
                    list.Add(new ShopCartItemViewModel()
                    {
                        Count = item.Count,
                        ProductID = item.ProductID,
                        Title = product.ProductTitle,
                        ImageName = product.ImageName

                    });
                }
            }

            return View(list);
        }
    }
}