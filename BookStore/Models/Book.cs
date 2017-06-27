using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
    
namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        
        public int Edition { get; set; }

        public Decimal Price { get; set; }

        public ApplicationUser Users { get; set; }

        
        public string UserId { get; set; }

        public Category Categorys { get; set; }

        public int CategoryId { get; set; }

    }
}