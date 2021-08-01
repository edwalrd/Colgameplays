using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Model.Option
{
   public class ForgotPassword
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
