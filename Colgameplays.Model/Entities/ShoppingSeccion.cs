using Colgameplays.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Entities
{
    public class ShoppingSeccion
    {

        public ShoppingSeccion()
        {
           Cart_Item = new HashSet<Cart_Item>();
        }
        public int Id { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }

        public decimal Total { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public ICollection<Cart_Item>  Cart_Item { get; set; }
    }
}
