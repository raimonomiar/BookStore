using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class OrderViewModel
    {

    
        public OrderViewModel()
        {
            Carts = new List<Cart>();
        }

        public List<Cart> Carts { get; set; }
    }
}