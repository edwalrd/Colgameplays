using Colgameplays.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class Usuario
    {
        public Usuario()
        {
            Carrito = new HashSet<Carrito>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public Roles Role { get; set; }
        public string FechaCreacion { get; set; }

        //---------
        public ICollection<Carrito> Carrito { get; set; }

        //------------
        public Domicilio Domicilio { get; set; }
        //------------
        public ICollection<Orden> Orden { get; set; }
    }
}
