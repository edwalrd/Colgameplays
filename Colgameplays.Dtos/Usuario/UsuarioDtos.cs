using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colgameplays.Dtos
{
   public class UsuarioDtos
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string User { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Password { get; set; }
        public string role { get; set; }
    }
  

}
