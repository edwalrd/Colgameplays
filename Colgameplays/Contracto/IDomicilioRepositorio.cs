using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
   public interface IDomicilioRepositorio
    {
/*        Task<List<Domicilio>> All();
        Task<List<Domicilio>> Search(string search);*/
        Task<Domicilio> One(int id);
        Task<Domicilio> Add(Domicilio domicilio);
        Task<bool> Put( int id , Domicilio domicilio);
        Task<bool> Delete(int id);
    }
}
