using Colgameplays.Enumerations;
using Colgameplays.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class Articulo
    {
        public Articulo()
        {
            Imagen = new HashSet<Imagen>();
            DetalleOrden = new HashSet<DetalleOrden>();
        }
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public Estado Estado { get; set; }

        public string Linkvideo { get; set; }

        public DateTime Fecha { get; set; }

        //----------

        public int Idconsola { get; set; }

        [ForeignKey("Idconsola")]
        public Consola Consola { get; set; }
        //----------
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
        //---------
        public Carrito Carrito { get; set; }
        //----
        public ICollection<Imagen> Imagen { get; set; }
        public ICollection<DetalleOrden> DetalleOrden { get; set; }


    }
}
