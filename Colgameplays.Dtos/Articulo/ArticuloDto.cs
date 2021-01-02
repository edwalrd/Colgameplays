using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Articulo
{
   public class ArticuloDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public string Estado { get; set; }

        public string Linkvideo { get; set; }

        public int Idconsola { get; set; }

        public int IdCategoria { get; set; }
    }
}
