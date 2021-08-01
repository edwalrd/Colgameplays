using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.OrderDtos
{
    public class OrderDtos
    {
        public int id { get; set; }

        public int IdUser { get; set; }
        public int discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public List<OrderDetailDtos> OrderDetails { get; set; }
    }
}
