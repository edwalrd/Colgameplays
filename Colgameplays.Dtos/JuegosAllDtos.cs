using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos
{
   public class JuegosAllDtos
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public double precio { get; set; }

        public string descripcion { get; set; }
        public string idioma { get; set; }

        public string publicacion { get; set; }

        public int idconsola { get; set; }

        public ConsolasDtos Consola { get; set; }
    }
}
