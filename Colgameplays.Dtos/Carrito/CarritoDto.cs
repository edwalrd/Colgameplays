using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Carrito
{
   public class CarritoDto
    {

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }

    }
}
