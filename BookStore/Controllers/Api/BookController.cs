using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BookStore.Repository;

namespace BookStore.Api.Controllers
{


    [Authorize]
    public class BookController : ApiController
    {
        private readonly IBookRepository repoB;

        public BookController(IBookRepository _repoB)
        {
            repoB = _repoB;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
           

            var userId = User.Identity.GetUserId();

            var book = repoB.FindBook(id, userId);

            repoB.Delete(book);

            return Ok();
        }
    }
}
