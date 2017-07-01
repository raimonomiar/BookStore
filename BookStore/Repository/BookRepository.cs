using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using BookStore.Models;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Add(Book model)
        {
            _context.Books.Add(model);
            _context.SaveChanges();
        }

        public IEnumerable<Book> Browse(int id)
        {
            return _context.Books
                .Where(b => b.CategoryId==id)
                .ToList();
        }

        public void Delete(Book model)
        {
            _context.Books.Remove(model);
            _context.SaveChanges();
        }

        public void Edit(Book model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Book FindBook(int id, string userid)
        {
            return _context.Books
                .Include(c => c.Categorys)
                .Include(u => u.Users)
                .SingleOrDefault(b => b.Id == id && b.UserId == userid);
        }

        public IEnumerable<Book> FindByID(string id)
        {



            return _context.Books
                .Where(b => b.UserId == id)
                .Include(b=>b.Categorys)
                .ToList();

        }
    }
}