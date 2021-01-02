using Colgameplays.Context;
using Colgameplays.Contracto;
using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repositorio
{
    public class AuthRepositorio : IAuthRepositorio
    {
        private readonly ColgamesplaysContenxt _context;

        public AuthRepositorio(ColgamesplaysContenxt context)
        {
            _context = context;
        }

        public async Task<Usuario> UserID(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> LoginUser(string user)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.User == user);
        }

        public async Task<Usuario> RegistrarUser(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuario;
        }


    }
}
