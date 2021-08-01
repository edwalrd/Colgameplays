using Colgameplays.Dtos.AddressDtos;
using Colgameplays.Dtos.ShoppingSeccionDtos;
using Colgameplays.Model.Option;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.User
{
   public class CreateUserDtos
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required ")]
        [FirstCapitalLetter]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        [FirstCapitalLetter]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        [MinLength(6 , ErrorMessage ="Solo se permiten mas de 6 digitos")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        [Range(18 , 100 , ErrorMessage ="Solo se permiten mayores de edad")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This field is required ")]
        public string Role { get; set; }
        public List<AddressDto>  Address { get; set; }
        public ShoppingSeccionDto ShoppingSeccion { get; set; }
    }
}
