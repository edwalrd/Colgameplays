using Colgameplays.Dtos.ImagenDtos;
using Colgameplays.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
   public interface IimagesRepository
    {
        Task<Image> One(int id);
        Task<string> Upload(IFormFile archivo , string contenedor);
        Task<Image> Add(Image imagen);
        Task<bool> Delete(int id , string container);
        Task<bool> UpdateImagen(int id, UpdateImageDtos dtos , string container);
    }
}
