using BookStore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace BookStore.Controllers.Api
{
    [Authorize]
    public class CartController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddToCart(int id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var cart = new Cart
            {
                BookId = id,
                UserId = User.Identity.GetUserId()

            };

            _context.Carts.Add(cart);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult CountCart()
        {
            var userid = User.Identity.GetUserId();

            var count = _context.Carts
                .Where(u=>u.UserId == userid)
                .Count();


            return Ok(count);
        }

        [HttpDelete]
        public IHttpActionResult RemoveCart(int id)
        {

            if (id==0)
            {
                return NotFound();
            }
            var userid = User.Identity.GetUserId();
            
            var getcart = _context.Carts
                .SingleOrDefault(c => c.Id == id && c.UserId == userid );

            _context.Carts.Remove(getcart);
            _context.SaveChanges();

            return Ok();

        }

      
    }
}
