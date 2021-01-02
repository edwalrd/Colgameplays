using Colgameplays.Context;
using Colgameplays.Contracto;
using Colgameplays.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repositorio
{
    public class PlataformaRepositorio: IPlataformaRepositorio
    {
        private ColgamesplaysContenxt _context;

       public  PlataformaRepositorio(ColgamesplaysContenxt contenxt)
        {
            _context = contenxt;
        }


        public async Task<List<Plataforma>> GetPlataformaAsyn()
        {
            return await _context.Plataformas.ToListAsync();
        }

        public async Task<Plataforma> GetOnePlataformaAsyn(int id)
        {
            return await _context.Plataformas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Plataforma>> SearchPlataformaAsyn(string search)
        {
            var datos = await _context.Plataformas.Where(x => x.nombre.Contains(search)).ToListAsync();

            if(datos == null)
            {
                return null;
            }

            return datos;
        }

        public async Task<Plataforma> AddPlataforma(Plataforma plataforma)
        {

            _context.Plataformas.Add(plataforma);

            try
            {
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                return null;
            }

            return plataforma;
        }


        public async Task<bool> DeletePlataformas(int id)
        {
            var platanforma = await _context.Plataformas.SingleOrDefaultAsync(x => x.Id == id); ;

            try { 
            
            if(platanforma == null)
            {
                return false;
            }

             _context.Plataformas.Remove(platanforma);

            return (await _context.SaveChangesAsync() > 0 ? true : false);

            }catch(Exception ex)
            {

                return false;
            }


        }


        public async Task<bool> PutPlataforma(int id , Plataforma plataforma)
        {
          
            var data = await _context.Plataformas.SingleOrDefaultAsync(x => x.Id == id);

            if(data == null)
            {
                return false;
            }

            data.nombre = plataforma.nombre;

            try
            {

                _context.Plataformas.Update(data);

                return await _context.SaveChangesAsync() > 0 ? true : false;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
