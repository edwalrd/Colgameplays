using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
    public interface ICategoriaRepositorio
    {

        Task<List<Categoria>> All();
        Task<List<Categoria>> Search(string search);
        Task<Categoria> One(int id);
        Task<Categoria> Add(Categoria categoria);
        Task<bool> Put(int id, Categoria categoria);

        Task<bool> Delete(int id);

    }
}
