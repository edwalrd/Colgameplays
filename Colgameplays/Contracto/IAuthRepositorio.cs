using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
   public interface IAuthRepositorio
    {
        Task<Usuario> UserID(int id);
        Task<Usuario> LoginUser(string user);
        Task<Usuario> RegistrarUser(Usuario usuario);
    }
}
