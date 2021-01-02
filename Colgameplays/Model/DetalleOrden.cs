using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class DetalleOrden
    {
        public int Id { get; set; }

        //------------
        public int IdArticulo { get; set; }

        [ForeignKey("IdArticulo")]
        public Articulo Articulo { get; set; }

        public int Cantidad { get; set; }

        public double PrecioUnitario { get; set; }

        public double SubTotal { get; set; }
        //-------------
        public int IdOrden { get; set; }

        [ForeignKey("IdOrden")]
        public Orden Orden { get; set; }

    }
}
