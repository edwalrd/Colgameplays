using Colgameplays.Contract;
using Colgameplays.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ColgameplaysContext _context;

        public OrderRepository(ColgameplaysContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> All()
        {
            return await _context.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Article).ToListAsync();
        }

        public async Task<List<Order>> searchbydate(string search)
        {
            return await _context.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Article)
                .Where(x => x.Fecha == Convert.ToDateTime(search) ).ToListAsync();

        }

        public async Task<Order> One (int id)
        {
            return await _context.Orders.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Order> Add(Order order)
        {
            _context.Orders.Add(order);

           await  _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> Update(int id , Order order)
        {
            var data = await One(id);

            data.IdUser = order.IdUser;
            data.discount = order.discount;
            data.IdUser = order.IdUser;
            data.SubTotal = data.SubTotal;
            data.Total = data.SubTotal - ((order.discount * data.SubTotal) / 100);


            _context.Orders.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);

        }

        public async Task<bool> UpdateOrderDetails(int id, OrderDetail orderDetail)
        {
            var data = await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);

            data.IdArticle = orderDetail.IdArticle;
            data.Unitprice = orderDetail.Unitprice;
            data.quantity = orderDetail.quantity;
            ////
            data.SubTotal = data.Unitprice * data.quantity ;

            _context.OrderDetails.Update(data);

            //cambiar el valor de "total" de la tabla order.

            var order = await _context.Orders.FirstOrDefaultAsync(x => x.id == data.IdOrder);
            order.discount = order.discount;
            order.SubTotal = data.SubTotal;
            order.Total = data.SubTotal - ((order.discount * data.SubTotal) / 100);

            _context.Orders.Update(order);

            return (await _context.SaveChangesAsync() > 0 ? true : false);

        }
        public async Task<bool> Delete(int id)
        {
            var data = await One(id);

            _context.Orders.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }
    }
}
