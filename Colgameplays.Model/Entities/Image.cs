using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Entities
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdArticle { get; set; }

        [ForeignKey("IdArticle")]
        public Article Article { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
