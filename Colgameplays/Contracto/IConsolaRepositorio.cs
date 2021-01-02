using Colgameplays.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{

    public interface IConsolaRepositorio
    {
        Task<List<Consola>> GetallConsolaAsyn();
        Task<List<Consola>> searchConsolaAsyn(string search);
        Task<Consola> GetoneConsola(int id);
        Task<Consola> AddConsola(Consola consola);
        Task<bool> PutConsola( int id , Consola consola);
        Task<bool> DeleteConsola( int id);
    }
}
