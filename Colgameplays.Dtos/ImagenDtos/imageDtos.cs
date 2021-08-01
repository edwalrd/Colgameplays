using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Dtos.ImagenDtos
{
    public class imageDtos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public List<IFormFile> Image { get; set; }

        public int IdArticle { get; set; }
    }
}
