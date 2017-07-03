using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository()
        {
            _context = new ApplicationDbContext();
        }
        public void Add(Cart model)
        {
            _context.Carts.Add(model);
            _context.SaveChanges();
        }

        public decimal CartTotal(List<Cart> cart)
        {
          return  cart.Sum(p => p.Books.Price);
        }

        public void ClearCart(IEnumerable<Cart> carts)
        {
            foreach (var item in carts)
            {
                _context.Carts.Remove(item);
                _context.SaveChanges();
            }
        }

        public int Count(string userid)
        {
            return _context.Carts
                .Where(c => c.UserId == userid)
                .Count();
        }

        public void Delete(Cart model)
        {
            _context.Carts.Remove(model);
            _context.SaveChanges();
        }

        public void Edit(Cart model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cart> FindByID(string id)
        {
            return _context.Carts
                .Include(b=>b.Books)
                .Where(c => c.UserId == id)
                .ToList();
        }

        public Cart GetCart(int id, string userid)
        {
            return _context.Carts
                .SingleOrDefault(c => c.Id == id && c.UserId == userid);
        }
    }
}