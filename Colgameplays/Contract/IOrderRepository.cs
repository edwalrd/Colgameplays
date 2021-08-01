using Colgameplays.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
   public interface IOrderRepository
    {

        Task<List<Order>> All();
        Task<List<Order>> searchbydate(String search);
        Task<Order> One(int id);
        Task<Order> Add(Order order);
        Task<bool> Update(int id, Order order);
        Task<bool> UpdateOrderDetails(int id, OrderDetail orderDetail);
        Task<bool> Delete(int id);
    }
}
