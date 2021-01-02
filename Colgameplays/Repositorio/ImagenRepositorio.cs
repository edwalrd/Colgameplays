using Colgameplays.Context;
using Colgameplays.Contracto;
using Colgameplays.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repositorio
{
    public class ImagenRepositorio: IimagenRepositorio
    {
        private readonly ColgamesplaysContenxt _context;
        private readonly IWebHostEnvironment env;
        public ImagenRepositorio(IWebHostEnvironment env , ColgamesplaysContenxt context)
        {
            _context = context;
            this.env = env;
        }

        public async Task<Imagen> Add (Imagen imagen)
        {
            _context.Imagens.Add(imagen);

            await _context.SaveChangesAsync();

            return imagen;
        }
        public async Task<string> Upload ( IFormFile archivo)
        {
            if (string.IsNullOrWhiteSpace(env.WebRootPath))
            {
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            var contenedore = "Articulos";
            var extension = Path.GetExtension(archivo.FileName);
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";

            string folder = Path.Combine(env.WebRootPath, contenedore);


            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string ruta = Path.Combine(folder, nombreArchivo);

            using (var fileStream = new FileStream(ruta, FileMode.Create))
            {
                await archivo.CopyToAsync(fileStream);
            }

            return nombreArchivo;

        }


        public async Task<bool> UpdateImagen(int id, IFormFile archivo)
        {
            var data = await _context.Imagens.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

             var valor =  this.DeleteImagen(data.Foto);

            if (!valor) return false;

            var nombre = await this.Upload(archivo);

               data.Foto = nombre;

            _context.Imagens.Update(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Delete(int id)
        {

            var data = await _context.Imagens.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

           var valor =  this.DeleteImagen(data.Foto);

            if (!valor) return false;

            _context.Imagens.Remove(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;

        }

        public  bool DeleteImagen(string foto)
        {
            var contenedore = "Articulos";

            if (string.IsNullOrWhiteSpace(env.WebRootPath))
            {
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            if (foto == null) return false;

            var adress =  Path.Combine(env.WebRootPath, contenedore, foto);

            if (File.Exists(adress))
            {
                 File.Delete(adress);
            }

            return  true;

        }
    }
}
