using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Model.Entities
{
   public class Cart_Item
    {
        public int Id { get; set; }

        public int IdShoppingSeccion { get; set; }
        [ForeignKey("IdShoppingSeccion")]
        public ShoppingSeccion shoppingSeccion { get; set; }

        public int IdArticle{ get; set; }
        [ForeignKey("IdArticle")]
        public Article Article { get; set; }

        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
