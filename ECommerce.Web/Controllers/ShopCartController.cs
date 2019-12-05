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
    public class ShopCartController : Controller
    {
        private readonly UnitOfWork<MyDbContext> db = new UnitOfWork<MyDbContext>();
        // GET: ShopCart
        //public ActionResult ShowCart()
        //{
        //    List<ShopCartItemViewModel> list = new List<ShopCartItemViewModel>();

        //    if (Session["ShopCart"] != null)
        //    {
        //        List<ShopCartItem> listShop = (List<ShopCartItem>)Session["ShopCart"];

        //        foreach (var item in listShop)
        //        {
        //            var product = db.Products.Where(p => p.ProductID == item.ProductID).Select(p => new
        //            {
        //                p.ImageName,
        //                p.Title
        //            }).Single();
        //            list.Add(new ShopCartItemViewModel()
        //            {
        //                Count = item.Count,
        //                ProductID = item.ProductID,
        //                Title = product.Title,
        //                ImageName = product.ImageName

        //            });
        //        }
        //    }

        //    return PartialView(list);
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //List<ShowOrderViewModel> getListOrder()
        //{
        //    List<ShowOrderViewModel> list = new List<ShowOrderViewModel>();

        //    if (Session["ShopCart"] != null)
        //    {
        //        List<ShopCartItem> listShop = Session["ShopCart"] as List<ShopCartItem>;

        //        foreach (var item in listShop)
        //        {
        //            var product = db.Products.Where(p => p.ProductID == item.ProductID).Select(p => new
        //            {
        //                p.ImageName,
        //                p.Title,
        //                p.Price
        //            }).Single();
        //            list.Add(new ShowOrderViewModel()
        //            {
        //                Count = item.Count,
        //                ProductID = item.ProductID,
        //                Price = product.Price,
        //                ImageName = product.ImageName,
        //                Title = product.Title,
        //                Sum = item.Count * product.Price
        //            });
        //        }
        //    }
        //    return list;
        //}

        //public ActionResult Order()
        //{
        //    return PartialView(getListOrder());
        //}

        //public ActionResult CommandOrder(int id, int count)
        //{
        //    List<ShopCartItem> listShop = Session["ShopCart"] as List<ShopCartItem>;
        //    int index = listShop.FindIndex(p => p.ProductID == id);
        //    if (count == 0)
        //    {
        //        listShop.RemoveAt(index);
        //    }
        //    else
        //    {
        //        listShop[index].Count = count;
        //    }
        //    Session["ShopCart"] = listShop;

        //    return PartialView("Order", getListOrder());
        //}

        //[Authorize]
        //public ActionResult Payment()
        //{
        //    int userId = db.Users.Single(u => u.UserName == User.Identity.Name).UserID;
        //    DataLayer.Orders order = new DataLayer.Orders()
        //    {
        //        UserID = userId,
        //        Date = DateTime.Now,
        //        IsFinaly = false,
        //    };
        //    db.Orders.Add(order);

        //    var listDetails = getListOrder();

        //    foreach (var item in listDetails)
        //    {
        //        db.OrderDetails.Add(new DataLayer.OrderDetails()
        //        {
        //            Count = item.Count,
        //            OrderID = order.OrderID,
        //            Price = item.Price,
        //            ProductID = item.ProductID,
        //        });
        //    }
        //    db.SaveChanges();

        //    //TODO : Online Payment

        //    return null;
        //}
    }
}