using Colgameplays.Dtos.Articulo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Orden
{

   public class GetDetalleOrdenDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double SubTotal { get; set; }
        public GetArticulosDto Articulo { get; set; }

    }
}
