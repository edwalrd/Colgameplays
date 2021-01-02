using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class Imagen
    {
        public int Id { get; set; }
        public string Foto { get; set; }
        //----------
        public int IdArticulo { get; set; }

        [ForeignKey("IdArticulo")]
        public Articulo Articulo { get; set; }


    }
}
