using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Usuario
{
    public class GetUsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string User { get; set; }
        public string role { get; set; }
    }
}
