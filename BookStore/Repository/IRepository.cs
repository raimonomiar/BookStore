using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);

        void Edit(T model);

        void Delete(T model);

        IEnumerable<T> FindByID(string id);
    }
}
