using Colgameplays.Contract;
using Colgameplays.Entities;
using Colgameplays.Model.Enumerations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ColgameplaysContext _context;

        public UserRepository(ColgameplaysContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetallAsyn()
        {
            return await _context.Users.ToListAsync();
        }



        public async Task<List<User>> GetallByRoleAsyn(string role)
        {
            return await _context.Users.Where(x => x.Role == (Roles)Enum.Parse(typeof(Roles), role)).ToListAsync();
        }

        public async Task<List<User>> GetUsersAddress(int id , string search)
        {
            return await _context.Users.Include(x => x.Address.Where(y => y.Ciudad.Contains(search) || y.Telefono.Contains(search))).Where(x => x.Id == id).ToListAsync();
        }

        public async Task<List<User>> SearchAsyn(string search)
        {
            return await _context.Users.Where(x => x.Name.Contains(search) || x.LastName.Contains(search) || x.LastName.Contains(x.Email)).ToListAsync();
        }

        public async Task<User> GetOneAsyn(int id)
        {
            return await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> Add(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Update(int id, User user)
        {
            var data = await GetOneAsyn(id);

            data.Name = user.Name;
            data.LastName = user.LastName;
            data.Email = user.Email;
            data.Age = user.Age;
            data.ModifiedDate = DateTime.Now;

            _context.Users.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);

        }
        public async Task<bool> Delete(int id)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            _context.Users.Remove(data);


            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }

        public async Task<bool> ChangePassowrd(User user, string Newpassword)
        {
            user.Password = Newpassword;

            _context.Users.Update(user);

            return await _context.SaveChangesAsync() > 0 ? true : false;

        }

        public async Task<bool> ChangeRole(int id, string role)
        {
            var data = await GetOneAsyn(id);

            data.Role = (Roles)Enum.Parse(typeof(Roles), role);

            _context.Users.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);

        }


        public async Task<ShoppingSeccion> OneShoppingSeccion(int id)
        {
            return await _context.ShoppingSeccions.FirstOrDefaultAsync(x => x.IdUser == id);
        }
    }
}
