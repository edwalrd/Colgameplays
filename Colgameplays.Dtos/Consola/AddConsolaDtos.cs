using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colgameplays.Dtos
{
   public class AddConsolaDtos
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public string Linkvideo { get; set; }
        public int Calificacion { get; set; }
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int Idplataforma { get; set; }
    }
}
