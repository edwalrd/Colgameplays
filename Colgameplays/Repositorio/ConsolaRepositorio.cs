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
    public class ConsolaRepositorio : IConsolaRepositorio
    {
        public ColgamesplaysContenxt _contexto;

        public ConsolaRepositorio(ColgamesplaysContenxt contexto )
        {
            _contexto = contexto;
        }

        public async Task<List<Consola>> GetallConsolaAsyn()
        {

           return await _contexto.Consolas.ToListAsync();
  
        }

        public async Task<Consola> GetoneConsola(int id)
        {
            return await _contexto.Consolas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Consola>> searchConsolaAsyn(string search)
        {
            var datos = await _contexto.Consolas.Where(x => x.Nombre.Contains(search)).ToListAsync();

            if(datos == null)
            {
                return null;
            }

            return datos;

        }
        public async Task<Consola> AddConsola(Consola consola)
        {
             _contexto.Consolas.Add(consola);

            try
            {
                await _contexto.SaveChangesAsync();
            } 
            catch(Exception ex)
            {
                return null;
            }
            
            return consola;
        }

        public async Task<bool> PutConsola(int id, Consola consola)
        {
            var data = await _contexto.Consolas.SingleOrDefaultAsync(x => x.Id == id);

            if (data  == null)
            {
                return false;
            }

            data.Nombre = consola.Nombre;
            data.Precio = consola.Precio;
            data.Descripcion = consola.Descripcion;
            data.Linkvideo = consola.Linkvideo;
            data.Calificacion = consola.Calificacion;
            data.Idplataforma = consola.Idplataforma;

            try
            {
                 _contexto.Consolas.Update(data);

                return await _contexto.SaveChangesAsync() > 0 ? true : false;

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public async Task<bool> DeleteConsola(int id)
        {
            var data = await _contexto.Consolas.SingleOrDefaultAsync(x => x.Id == id);

            try {
                if (data == null)
                {
                    return false; 
                }

                    _contexto.Remove(data);

                return (await _contexto.SaveChangesAsync() > 0 ? true : false);

            }
            catch(Exception ex)
            {
                return false;
            }


        }

    }
}
