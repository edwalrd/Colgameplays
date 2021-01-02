using Colgameplays.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{

   public interface IPlataformaRepositorio
    {

        Task<List<Plataforma>> GetPlataformaAsyn();
        Task<List<Plataforma>> SearchPlataformaAsyn(string search);

        Task<Plataforma> GetOnePlataformaAsyn(int id);

        Task<Plataforma> AddPlataforma(Plataforma plataforma);

        Task<bool> PutPlataforma(int id , Plataforma plataforma);

        Task<bool> DeletePlataformas(int id);

    }
}
