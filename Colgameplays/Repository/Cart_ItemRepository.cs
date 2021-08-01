using Colgameplays.Contract;
using Colgameplays.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class Cart_ItemRepository : ICart_ItemRepository
    {
        private readonly ColgameplaysContext _context;

        public Cart_ItemRepository(ColgameplaysContext context)
        {
            _context = context;
        }

      public async  Task<Cart_Item> One(int id)
        {
            return await _context.Cart_Items.Include(x => x.Article).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Cart_Item>> SearchByName(string search)
        {
            return await _context.Cart_Items.Include(x => x.Article.Name.Contains(search)).ToListAsync();
        }

        public async Task<List<Cart_Item>> SearchByDate(string Ddate, string Hdate)
        {
            return await _context.Cart_Items.Include(x => x.Article).Where(x => x.CreationDate >= Convert.ToDateTime(Ddate) && x.CreationDate <= Convert.ToDateTime(Hdate)).ToListAsync();
        }
        public async Task<List<Cart_Item>> SearchBYLimit(int num)
        {
            return await _context.Cart_Items.Include(x => x.Article).Take(num).ToListAsync();
        }


        public async Task<Cart_Item> Add (Cart_Item cart_Item)
        {
            var shopping = await _context.ShoppingSeccions.FirstOrDefaultAsync(x => x.Id == cart_Item.IdShoppingSeccion);

            var Article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == cart_Item.IdArticle);

            shopping.Total = shopping.Total + cart_Item.Quantity * Article.Price;

            _context.ShoppingSeccions.Update(shopping);

            _context.Cart_Items.Add(cart_Item);

            await _context.SaveChangesAsync();

            return cart_Item;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await One(id);

            var shopping = await _context.ShoppingSeccions.FirstOrDefaultAsync(x => x.Id == data.IdShoppingSeccion);
            var Article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == data.IdArticle);

            shopping.Total = shopping.Total - data.Quantity * Article.Price;

            _context.ShoppingSeccions.Update(shopping);

            _context.Cart_Items.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }
    }
}
