using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.ArticleDtos
{
  public  class CreateArticleDtos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Description { get; set; }
        public string LinkVideo { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int IdConsole { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int IdCategory { get; set; }
    }
}
