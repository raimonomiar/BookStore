using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    interface ICartRepository:IRepository<Cart>
    {
        int Count(string userid);

        Cart GetCart(int id, string userid);

        decimal CartTotal(List<Cart> cart);

        void ClearCart(IEnumerable<Cart> carts);
    }
}
