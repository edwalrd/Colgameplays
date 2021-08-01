using Colgameplays.Contract;
using Colgameplays.Dtos.ImagenDtos;
using Colgameplays.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class ImagesRepository : IimagesRepository
    {
        private readonly ColgameplaysContext _context;
        private readonly IWebHostEnvironment env;
        public ImagesRepository(IWebHostEnvironment env,  ColgameplaysContext context)
        {
            _context = context;
            this.env = env;
        }

        public async Task<Image> One(int id)
        {
            return await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Image> Add(Image imagen)
        {
            _context.Images.Add(imagen);

            await  _context.SaveChangesAsync();

            return imagen;
        }

        public async  Task<string> Upload(IFormFile archivo , string container)
        {

            if (string.IsNullOrWhiteSpace(env.WebRootPath))
            {
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            var extension = Path.GetExtension(archivo.FileName);
            var nameFile = $"{Guid.NewGuid()}{extension}";

            string folder = Path.Combine(env.WebRootPath, container);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string route = Path.Combine(folder, nameFile);

            using (var fileStream = new FileStream(route, FileMode.Create))
            {
                await archivo.CopyToAsync(fileStream);
            }

            return nameFile;

        }

        public async Task<bool> UpdateImagen(int id, UpdateImageDtos dtos, string container)
        {
            var data = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            var valor = this.DeleteImagen(data.Name , container);

            if (!valor) return false;

            var nombre = await this.Upload(dtos.Image, container);

            data.Name = nombre;
            data.IdArticle = dtos.IdArticle;

            _context.Images.Update(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Delete(int id , string container)
        {

            var data = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            var valor = this.DeleteImagen(data.Name , container);

            if (!valor) return false;

            _context.Images.Remove(data);

            return await _context.SaveChangesAsync() > 0 ? true : false;

        }

        public bool DeleteImagen(string NameImage , string container)
        {

            if (string.IsNullOrWhiteSpace(env.WebRootPath))
            {
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            if (NameImage == null) return false;

            var adress = Path.Combine(env.WebRootPath, container, NameImage);

            if (File.Exists(adress))
            {
                File.Delete(adress);
            }

            return true;

        }

    }
}
