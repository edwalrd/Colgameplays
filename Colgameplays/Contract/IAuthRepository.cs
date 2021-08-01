using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
   public interface IAuthRepository
    {
        Task<User> UserID(int id);
        Task<User> LoginUser(string email);
        Task<User> RegistrarUser(User user);
        string GenerateToken(User user);
    }
}
