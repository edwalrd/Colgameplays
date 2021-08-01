using Colgameplays.Dtos.Category;
using Colgameplays.Dtos.Consoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.ArticleDtos
{
   public class AllArticleDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string LinkVideo { get; set; }
        public string Condition { get; set; }
        public CategoryDtos Category { get; set; }
        public ConsoleDtos Consoles { get; set; }
    }
}
