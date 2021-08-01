using Colgameplays.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.Cart_Item
{
   public class Cart_ItemDtos
    {
        public int id { get; set; }
        public int IdShoppingSeccion { get; set; }
        public int IdArticle { get; set; }
        public int Quantity { get; set; }

        public ArticleCart_Item Article { get; set; }
    }
}
