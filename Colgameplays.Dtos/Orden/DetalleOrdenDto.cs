using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Orden
{
  public  class DetalleOrdenDto
    {
        public int Id { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double SubTotal { get; set; }
        public int IdOrden { get; set; }

    }
}
