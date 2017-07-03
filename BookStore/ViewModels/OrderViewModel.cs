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
            Detail = new List<OrderDetail>();
        }

        public List<OrderDetail> Detail{ get; set; }

        public decimal Total { get; set ; }
    }
}