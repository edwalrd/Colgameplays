using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.OrderDtos
{
   public class AddOrderDtos
    {
        public int id { get; set; }
        public int IdUser { get; set; }
        public int discount { get; set; }
        public decimal SubTotal { get { return OrderDetails.Sum(x => x.SubTotal); } }
        public decimal Total { get { return SubTotal - ((discount * SubTotal) / 100); } }
        public List<OrderDetailDtos> OrderDetails { get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    }
}

