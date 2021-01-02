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
    public class CategoriaRepositorio: ICategoriaRepositorio
    {
        private readonly ColgamesplaysContenxt _context;

        public CategoriaRepositorio(ColgamesplaysContenxt context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> All()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<List<Categoria>> Search(string search)
        {
            var datos = await _context.Categorias.Where(x => x.Nombre.Contains(search)).ToListAsync();

            if (datos == null) return null;

            return datos;
        }

        public async Task<Categoria> One (int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Categoria> Add (Categoria categoria)
        {    
            _context.Categorias.Add(categoria);
              
            await _context.SaveChangesAsync();

            return categoria;
            
        }

        public async Task<bool> Put (int id , Categoria categoria)
        {
            var data = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            data.Nombre = categoria.Nombre;

            _context.Categorias.Update(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Delete (int id)
        {
            var datos = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);

            if (datos == null) return false;

             _context.Categorias.Remove(datos);

            return (await _context.SaveChangesAsync() > 0 ? true : false);

        }

    }
}
