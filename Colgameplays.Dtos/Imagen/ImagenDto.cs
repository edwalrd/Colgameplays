using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colgameplays.Dtos.Imagen
{
   public class ImagenDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        public List<IFormFile> Foto { get; set; }
        //----------
        public int IdArticulo { get; set; }
    }
}
