using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
   public  interface IOrdenesRepositorio
    {
        Task<List<Orden>> All();
        Task<List<Orden>> Search(string search);
        Task<Orden> One(int id);
        Task<Orden> Add(Orden orden);
        Task<bool> Delete(int id);
    }
}
