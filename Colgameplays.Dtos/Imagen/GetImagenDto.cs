using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Imagen
{
   public class GetAddImagenDto
    {
        public int Id { get; set; }
        public string Foto { get; set; }
        //----------
        public int IdArticulo { get; set; }
    }
}
