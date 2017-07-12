using BookStore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using BookStore.ViewModels;
using BookStore.Repository;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartRepository repoC;

        private readonly IOrderRepository repoO;

        public CartController(ICartRepository _repoC, IOrderRepository _repoO)
        {
            repoC = _repoC;

            repoO = _repoO;

        }

        [ChildActionOnly]
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();

            var cart = (List<Cart>)repoC.FindByID(userid);

           
            
            return PartialView("_PartialCart",cart);
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetOrder()
        {

            var userid = User.Identity.GetUserId();

            var cart = (List<Cart>)repoC.FindByID(userid);

            var order = new Order
            {
                Date = DateTime.Now,
                Units = repoC.Count(userid),
                Total=repoC.CartTotal(cart),
                UserId = User.Identity.GetUserId()

            };
            repoO.Add(order);

            foreach (var item in cart)
            {
                var orderDetail = new OrderDetail
                {
                    BookId = item.BookId,
                    OrderId = order.Id,
                    Price = item.Books.Price,
                    UserId = item.UserId,

                };
                repoO.Add(orderDetail);
            }

          

            repoC.ClearCart(cart);
            repoO.Save();
            var orderModel = new OrderViewModel
            {
                Detail = repoO.GetDetail(userid,order.Id),
                Total = order.Total
            };



            return View("OrderSummary",orderModel);
        } 


    }
}