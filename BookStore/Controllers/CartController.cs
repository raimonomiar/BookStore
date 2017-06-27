using BookStore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using BookStore.ViewModels;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Cart
        
        [ChildActionOnly]
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();

            var cart = _context.Carts
                .Include(b => b.Books)
                .Where(u => u.UserId == userid)
                .ToList();

            var orderModel = new OrderViewModel()
            {
                Carts = cart
            };
            
            return PartialView("_PartialCart",orderModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetOrder()
        {

            var userid = User.Identity.GetUserId();

            var cart = _context.Carts
                .Include(b => b.Books)
                .Where(u => u.UserId == userid)
                .ToList();

            var unit = cart.Count;

            var total = cart.Sum(p => p.Books.Price);

            var order = new Order
            {
                Date = DateTime.Now,
                Units = unit,
                Total=total,
                UserId = User.Identity.GetUserId()

            };
            _context.Orders.Add(order);

            foreach (var item in cart)
            {
                var orderDetail = new OrderDetail
                {
                    BookId = item.BookId,
                    OrderId = order.Id,
                    Price = item.Books.Price,
                    UserId = item.UserId,

                };
                _context.Details.Add(orderDetail);
            }

            _context.SaveChanges();
            return View("Index", "Cart");
        }


    }
}