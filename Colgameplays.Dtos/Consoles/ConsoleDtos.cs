using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.Consoles
{
    public class ConsoleDtos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int IdBrand { get; set; }
    }
}
