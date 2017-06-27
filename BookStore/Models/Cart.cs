using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public Book Books { get; set; }

        public int BookId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }
}