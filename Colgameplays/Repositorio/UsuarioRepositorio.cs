using Colgameplays.Context;
using Colgameplays.Contracto;
using Colgameplays.Dtos;
using Colgameplays.Enumerations;
using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ColgamesplaysContenxt _context;

        public UsuarioRepositorio(ColgamesplaysContenxt context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> AllusersAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<List<Usuario>> SearchUsersAsync(string search)
        {
            var datos = await _context.Usuarios.Where(x =>  x.User.Contains(search) || x.Nombre.Contains(search) || x.Apellido.Contains(search) ).ToListAsync();

            if (datos == null)
            {
                return null;
            }

            return datos;
        }


        public async Task<Usuario> OneUserAsync (int id)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Usuarios.SingleOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            _context.Usuarios.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }

        public async Task<bool> ChangeRoleUser(int id , roleDto role)
        {
            var data = await _context.Usuarios.SingleOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            data.Role =  (Roles)Enum.Parse(typeof(Roles) , role.role);

            _context.Usuarios.Update(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;


        }


    }
}
