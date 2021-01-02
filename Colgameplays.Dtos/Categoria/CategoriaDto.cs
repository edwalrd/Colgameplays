using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colgameplays.Dtos.Categoria
{
   public class CategoriaDto
    {
       
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

    }
}
