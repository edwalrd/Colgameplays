using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Model.Entities
{
   public class OrderDetail
    {
        public int Id { get; set; }

        public int IdArticle { get; set; }

        [ForeignKey("IdArticle")]
        public Article Article { get; set; }
        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public Order Order { get; set; }
        public decimal Unitprice { get; set; }
        public int quantity { get; set; }
        public decimal SubTotal { get; set; }

    }
}
