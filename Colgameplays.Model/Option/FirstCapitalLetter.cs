using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Model.Option
{
   public class FirstCapitalLetter : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var word = value.ToString()[0].ToString();

            if(word != word.ToUpper())
            {
                return new ValidationResult("La primera letra debe ser mayúscula");
            }

            return ValidationResult.Success;
        }
    }
}
