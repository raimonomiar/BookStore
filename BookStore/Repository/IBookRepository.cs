using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Book FindBook(int id,string userid);

        IEnumerable<Book> Browse(int id);
    }
}
