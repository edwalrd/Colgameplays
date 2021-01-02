using Colgameplays.Dtos;
using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
   public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> AllusersAsync();
        Task<List<Usuario>> SearchUsersAsync(string search);
        Task<Usuario> OneUserAsync(int id);

        Task<bool> Delete(int id);

        Task<bool> ChangeRoleUser(int id, roleDto role);
        
    }
}
