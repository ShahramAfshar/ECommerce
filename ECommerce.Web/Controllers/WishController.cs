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
        // GET: Wish
        // GET: Shop
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
    }
}