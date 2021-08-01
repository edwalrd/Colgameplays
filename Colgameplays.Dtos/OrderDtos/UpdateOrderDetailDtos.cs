using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.OrderDtos
{
    public class UpdateOrderDetailDtos
    {
        public int Id { get; set; }
        public int IdArticle { get; set; }
        public decimal Unitprice { get; set; }
        public int quantity { get; set; }
    }
}
