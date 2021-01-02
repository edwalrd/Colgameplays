using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
   public interface IArticuloRepositorio
    {
        Task<List<Articulo>> All();
        Task<List<Articulo>> Search(string search);
        Task<Articulo> One(int id);
        Task<Articulo> Add(Articulo articulo);
        Task<bool> Put(int id, Articulo articulo);
        Task<bool> Delete(int id);
    }
}
