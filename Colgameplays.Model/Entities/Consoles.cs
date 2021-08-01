using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Entities
{
    public class Consoles
    {
        public Consoles()
        {
            Articles = new HashSet<Article>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdBrand { get; set; }

        [ForeignKey("IdBrand")]
        public Brand Brand { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
