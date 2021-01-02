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
    public class CarritoRepositorio : ICarritoRepositorio
    {
        private readonly ColgamesplaysContenxt _context;

        public CarritoRepositorio(ColgamesplaysContenxt context)
        {
            _context = context;
        }

        public async Task<List<Carrito>> All()
        {
            return await _context.Carritos.Include(x => x.Articulo).ToListAsync();

        }

        public async Task<List<Carrito>> Search(string search)
        {
            return await _context.Carritos.Include(x => x.Articulo).Where(x => x.Articulo.Nombre.Contains(search)).ToListAsync();

        }

        public async Task<Carrito> One(int id)
        {
            return await _context.Carritos.Include(y => y.Articulo).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Carrito> Add(Carrito carrito)
        {
           
            _context.Carritos.Add(carrito);
          
                await _context.SaveChangesAsync();

            return carrito;
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Carritos.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            _context.Carritos.Remove(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

    }
}
