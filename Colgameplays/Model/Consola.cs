using Colgameplays.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.model
{
    public class Consola
    {
        public Consola()
        {
            Articulo = new HashSet<Articulo>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }
        public string Descripcion  { get; set; }
        public string Linkvideo  { get; set; }

        public int Calificacion { get; set; }

        public int Idplataforma { get; set; }

        [ForeignKey("Idplataforma")]
        public Plataforma Plataforma { get; set; }

        public ICollection<Articulo> Articulo { get; set; }


    }
}
