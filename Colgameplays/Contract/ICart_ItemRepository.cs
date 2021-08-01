using Colgameplays.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
    public interface ICart_ItemRepository
    {
        Task<Cart_Item> One(int id);
        Task<List<Cart_Item>> SearchByName(string search);
        Task<List<Cart_Item>> SearchByDate(string Ddate , string Hdate);
        Task<List<Cart_Item>> SearchBYLimit(int num);
        Task<Cart_Item> Add(Cart_Item cart_Item);
        Task<bool> Delete(int id);


    }
}
