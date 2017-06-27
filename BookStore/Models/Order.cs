using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Units{ get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public List<OrderDetail> Details { get; set; }
    }
}