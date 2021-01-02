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
    public class OrdenesRepositorio: IOrdenesRepositorio
    {
        private readonly ColgamesplaysContenxt _context;

        public OrdenesRepositorio(ColgamesplaysContenxt context)
        {
            _context = context;
        }

        public async Task<List<Orden>> All()
        {
            return await _context.Ordens
                .Include(x => x.Usuario)
                .Include(x => x.DetalleOrden).ThenInclude(y => y.Articulo).ToListAsync();
        }

        public async Task<List<Orden>> Search(string search)
        {
            return await _context.Ordens
                .Include(x => x.Usuario)
                .Include(x => x.DetalleOrden).ThenInclude(y => y.Articulo)
                .ToListAsync();
        }

        public async Task<Orden> One(int id)
        {
            return await _context.Ordens
                .Include(x => x.Usuario)
                .Include(x => x.DetalleOrden).ThenInclude(y => y.Articulo).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Orden> Add (Orden orden)
        {
       
            _context.Ordens.Add(orden);

            await _context.SaveChangesAsync();

            return orden;
        }

        public async Task<bool> Delete (int id)
        {
            var data = await _context.Ordens.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            _context.Ordens.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }

        public async Task<bool> PutDetalleOrden(int id, DetalleOrden detalleOrden)
        {
            var data = await _context.DetalleOrdens.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            data.Cantidad = detalleOrden.Cantidad;
            data.PrecioUnitario = detalleOrden.PrecioUnitario;
            data.SubTotal = detalleOrden.SubTotal;

            _context.DetalleOrdens.Update(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
