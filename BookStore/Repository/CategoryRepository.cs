using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Models;

namespace BookStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Add(Category model)
        {
            _context.Categorys.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Category model)
        {
            throw new NotImplementedException();
        }

        public void Edit(Category model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> FindByID(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategory()
        {
            return _context.Categorys.ToList();
        }
    }
}