using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
   public interface IUserRepository: IGenericRepository<User>
    {
        Task<List<User>> GetallByRoleAsyn(string role);

        Task<List<User>> GetUsersAddress(int id, string Serch);

        Task<bool> ChangePassowrd(User user, string Password);

        Task<bool> ChangeRole(int id, string role);

        Task<ShoppingSeccion> OneShoppingSeccion(int id);

    }
}
