using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Add(OrderDetail model)
        {
            _context.Details.Add(model);
        }

        public void Add(Order model)
        {
            _context.Orders.Add(model);
        }

        public void Delete(Order model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> FindByID(string id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> GetDetail(string userid,int orderid)
        {
            return _context.Details
                .Include(b=>b.Books)
                .Where(o => o.UserId == userid && o.OrderId == orderid)
                .ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}