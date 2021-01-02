using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class Carrito
    {
        public int Id { get; set; }
        //
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        //
        public int IdArticulo { get; set; }
        [ForeignKey("IdArticulo")]
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}
