using BookStore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using BookStore.Repository;

namespace BookStore.Controllers.Api
{
    [Authorize]
    public class CartController : ApiController
    {
        private readonly ICartRepository repoC; 

        public CartController(ICartRepository _repoC)
        {
            repoC = _repoC;
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

            repoC.Add(cart);

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult CountCart()
        {
            var userid = User.Identity.GetUserId();

            var count = repoC.Count(userid);

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
            
            var getcart =repoC.GetCart(id, userid);

            repoC.Delete(getcart);

            return Ok();

        }

      
    }
}
