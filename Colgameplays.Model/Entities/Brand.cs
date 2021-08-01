using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Entities
{
    public class Brand
    {
        public Brand()
        {
            Consoles = new HashSet<Consoles>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<Consoles> Consoles { get; set; }

    }
}
