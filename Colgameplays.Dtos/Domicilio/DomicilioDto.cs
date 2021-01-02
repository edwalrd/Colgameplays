using System;
using System.Collections.Generic;
using System.Text;

namespace Colgameplays.Dtos.Domicilio
{
  public  class DomicilioDto
    {
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int IdUsuario { get; set; }
    }
}
