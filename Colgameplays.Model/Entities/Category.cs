using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Entities
{
    public class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
