using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.OrderDtos
{
    public class OrderDetailDtos
    {
        public int Id { get; set; }
        public int IdArticle { get; set; }
        public int IdOrder { get; set; }
        public decimal Unitprice { get; set; }
        public int quantity { get; set; }
        public decimal SubTotal { get { return Unitprice * quantity; } }

    }
}
