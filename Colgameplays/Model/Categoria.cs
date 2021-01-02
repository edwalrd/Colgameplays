using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class Categoria
    {

        public Categoria()
        {
            Articulo = new HashSet<Articulo>();
        }
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<Articulo> Articulo { get; set; }
    }
}
