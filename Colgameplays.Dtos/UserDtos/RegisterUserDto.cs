using Colgameplays.Dtos.ShoppingSeccionDtos;
using Colgameplays.Model.Option;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.UserDtos
{
    public class RegisterUserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [FirstCapitalLetter]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [FirstCapitalLetter]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [MinLength(6, ErrorMessage = "Solo se permiten mas de 6 digitos")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este Campo es obligatorio")]
        [Range(18, 100, ErrorMessage = "Solo se permiten mayores de edad")]
        public int Age { get; set; }
        public ShoppingSeccionDto ShoppingSeccion { get; set; }
    }
}
