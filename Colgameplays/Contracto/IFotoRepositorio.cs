using Colgameplays.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{

   public interface IimagenRepositorio
    {
        Task<string> Upload(IFormFile archivo);
        Task<Imagen> Add(Imagen imagen);
        Task<bool> Delete(int id);
        Task<bool> UpdateImagen(int id , IFormFile archivo);
    }
}
