using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Model.Entities
{
   public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int id { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }

        public int discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public DateTime Fecha { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
