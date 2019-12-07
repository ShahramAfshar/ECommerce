using ECommerce.Data;
using ECommerce.Data.DatabaseContext;
using ECommerce.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ECommerce.Web.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();


        // GET: Shop
        public int Get()
        {
            List<ShopCartItem> list = new List<ShopCartItem>();
            // var sessions = HttpContext.Current.Session;
            if (Session["ShopCart"] != null)
            {
                list = Session["ShopCart"] as List<ShopCartItem>;
            }

            return list.Sum(l => l.Count);
        }

        // GET: api/Shop/5
        public int AddToBasket(int id)
        {
            List<ShopCartItem> list = new List<ShopCartItem>();
            //var sessions = HttpContext.Current.Session;
            if (Session["ShopCart"] != null)
            {
                list = Session["ShopCart"] as List<ShopCartItem>;
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

            Session["ShopCart"] = list;
            return Get();
        }

        public ActionResult ShowCart()
        {
            List<ShopCartItemViewModel> list = new List<ShopCartItemViewModel>();

            if (Session["ShopCart"] != null)
            {
                List<ShopCartItem> listShop = (List<ShopCartItem>)Session["ShopCart"];

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

        public ActionResult Index()
        {
            return View();
        }

        List<ShowOrderViewModel> getListOrder()
        {
            List<ShowOrderViewModel> list = new List<ShowOrderViewModel>();

            if (Session["ShopCart"] != null)
            {
                List<ShopCartItem> listShop = Session["ShopCart"] as List<ShopCartItem>;

                foreach (var item in listShop)
                {
                    var product = db.ProductRepository.GetById(item.ProductID);
                    list.Add(new ShowOrderViewModel()
                    {
                        Count = item.Count,
                        ProductID = item.ProductID,
                        Price = product.Price,
                        ImageName = product.ImageName,
                        Title = product.ProductTitle,
                        Sum = item.Count * product.Price
                    });
                }
            }
            return list;
        }

        public ActionResult Order()
        {
            return PartialView(getListOrder());
        }

        public ActionResult CommandOrder(int id, int count)
        {
            List<ShopCartItem> listShop = Session["ShopCart"] as List<ShopCartItem>;
            int index = listShop.FindIndex(p => p.ProductID == id);
            if (count == 0)
            {
                listShop.RemoveAt(index);
            }
            else
            {
                listShop[index].Count = count;
            }
            Session["ShopCart"] = listShop;

            return PartialView("Order", getListOrder());
        }

        [Authorize]
        public ActionResult Payment()
        {
            //string userId = db.Users.Single(u => u.UserName == User.Identity.Name).UserID;
            Order order = new Order()
            {
                Id = User.Identity.GetUserId(),
                Date = DateTime.Now,
                IsFinaly = false,
            };
            db.OrderRepository.Insert(order);

            var listDetails = getListOrder();

            foreach (var item in listDetails)
            {
                db.OrderDetailRepository.Insert(new OrderDetail()
                {
                    Count = item.Count,
                    OrderID = order.OrderID,
                    Price = item.Price,
                    ProductID = item.ProductID,
                });
            }
            db.Commit();

            //TODO : Online Payment

            return null;
        }

        public ActionResult DeleteShopCart(int id)
        {

            List<ShopCartItem> listShop = (List<ShopCartItem>)Session["ShopCart"];

            int index = listShop.FindIndex(p => p.ProductID == id);

            listShop.RemoveAt(index);
            Session["ShopCart"] = listShop;

            return RedirectToAction("ShowCart");
        }
    }
}