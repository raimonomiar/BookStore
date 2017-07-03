using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    interface IOrderRepository:IRepository<Order>
    {
        void Add(OrderDetail model);
        void Save();
        List<OrderDetail> GetDetail(string userid,int orderid);
    }
}
