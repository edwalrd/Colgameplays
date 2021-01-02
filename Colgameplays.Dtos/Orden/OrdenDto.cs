using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Orden
{
   public class OrdenDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

        public List<DetalleOrdenDto> DetalleOrden { get; set; }
    }
}
