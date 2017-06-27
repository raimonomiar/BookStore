using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace BookStore.Api.Controllers
{
    [Authorize]
    public class BookController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public BookController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();

            var book = _context.Books
                .Single(b => b.Id == id && b.UserId == userId);

            _context.Books.Remove(book);

            _context.SaveChanges();

            return Ok();
        }
    }
}
