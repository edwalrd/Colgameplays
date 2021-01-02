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
    public class DomicilioRepositorio: IDomicilioRepositorio
    {
        private readonly ColgamesplaysContenxt _context;

        public DomicilioRepositorio(ColgamesplaysContenxt context)
        {
            _context = context;
        }

        public async Task<Domicilio> One(int id)
        {
            var data =  await _context.Domicilios.SingleOrDefaultAsync(x => x.Id == id);

            if (data == null) return null;

            return data;
        }

        public async Task<Domicilio> Add(Domicilio domicilio)
        {
            _context.Domicilios.Add(domicilio);

             await _context.SaveChangesAsync();

            return domicilio;
        }

        public async Task<bool> Put(int id ,  Domicilio domicilio)
        {
            var data = await _context.Domicilios.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            data.Ciudad = domicilio.Ciudad;
            data.Direccion = domicilio.Direccion;
            data.Telefono = domicilio.Telefono;
            data.Celular = domicilio.Celular;
            data.IdUsuario = domicilio.IdUsuario;

            _context.Domicilios.Update(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;

        }


        public async Task<bool> Delete (int id)
        {
            var data = await _context.Domicilios.SingleOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            _context.Domicilios.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);


        }

    }
}
