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
    public class ArticuloRepositorio: IArticuloRepositorio
    {
        private readonly ColgamesplaysContenxt _context;

        public ArticuloRepositorio(ColgamesplaysContenxt context)
        {
            _context = context;
        }

        public async Task<List<Articulo>> All()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<List<Articulo>> Search(string search)
        {
            return await _context.Articulos.Where(x => x.Nombre.Contains(search)).ToListAsync();
        }

        public async Task<Articulo> One(int id)
        {
            return await _context.Articulos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Articulo> Add(Articulo articulo)
        {
            _context.Articulos.Add(articulo);

            await _context.SaveChangesAsync();

            return articulo;
        }

        public async Task<bool> Put(int id, Articulo articulo)
        {
            var data = await _context.Articulos.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            data.Nombre = articulo.Nombre;
            data.Precio = articulo.Precio;
            data.Descripcion = articulo.Descripcion;
            data.Estado = articulo.Estado;
            data.Linkvideo = articulo.Linkvideo;
            data.IdCategoria = articulo.IdCategoria;
            data.Idconsola = articulo.Idconsola;

            _context.Articulos.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }
        public async Task<bool> Delete(int id)
        {
            var data = await _context.Articulos.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            _context.Articulos.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }
    }
}
