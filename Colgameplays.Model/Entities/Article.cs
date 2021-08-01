using Colgameplays.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Entities
{
    public class Article
    {
        public Article()
        {
            Images = new HashSet<Image>();
            OrderDetailS = new HashSet<OrderDetail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string LinkVideo { get; set; }
        public Condition Condition { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int IdConsole { get; set; }
        [ForeignKey("IdConsole")]
        public Consoles Consoles { get; set; }

        public int IdCategory { get; set; }

        [ForeignKey("IdCategory")]
        public Category Category { get; set; }

        // ------------------------/////
        public List<Cart_Item> Cart_Items { get; set; }
        public ICollection<OrderDetail> OrderDetailS { get; set; }
        public ICollection<Image> Images { get; set; }

    }
}
