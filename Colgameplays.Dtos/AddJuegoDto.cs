using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Colgameplays.Dtos
{
    public class AddJuegoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]

        public double precio { get; set; }

        public string descripcion { get; set; }
        public string idioma { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int idconsola { get; set; }
    }
}
