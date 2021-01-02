using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
   public interface ICarritoRepositorio
    {
        Task<List<Carrito>> All();
        Task<List<Carrito>> Search(string search);
        Task<Carrito> One(int id);
        Task<Carrito> Add(Carrito carrito);
        Task<bool> Delete(int id);

    }
}
