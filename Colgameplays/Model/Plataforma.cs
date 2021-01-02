using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.model
{
    public class Plataforma
    {
        public Plataforma()
        {
            Consolas = new HashSet<Consola>();
        }

        public int Id { get; set;  }

        public string nombre { get; set;  }

        public ICollection<Consola> Consolas { get; set; }
       
    }
}
