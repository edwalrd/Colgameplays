using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.OrderDtos
{
    public class UpdateOrderDtos
    {
        public int id { get; set; }
        public int IdUser { get; set; }
        public int discount { get; set; }
    }
}
