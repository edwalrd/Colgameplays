using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class Orden
    {
        public Orden()
        {
            DetalleOrden = new HashSet<DetalleOrden>();
        }
        public int Id { get; set; }

        public int IdUsuario { get; set; }
        
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        //-----------
        public double Descuento { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }

        //------------
        public ICollection<DetalleOrden>  DetalleOrden { get; set; }

    }
}
