using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.AddressDtos
{
   public class AddressDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "This field is required ")]

        [MinLength(10 , ErrorMessage = "The minimum number of digits is 10") , MaxLength(10 , ErrorMessage = "The maximum number of digits is 10")]
        public string Telefono { get; set; }  
        //------------

    }
}
