using Colgameplays.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Orden
{
   public class GetOrdenDtos
    {
        public int Id { get; set; }

        public GetUsuarioDto Usuario { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

        public List<GetDetalleOrdenDto> DetalleOrden { get; set; }


    }
}
