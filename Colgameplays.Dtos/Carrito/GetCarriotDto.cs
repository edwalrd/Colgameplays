using Colgameplays.Dtos.Articulo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Carrito
{
   public class GetCarriotDto
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public  GetArticulosDto Articulo { get; set; }
    }
}
