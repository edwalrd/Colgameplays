using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Model.Entities
{
  public  class Address
    {
        public int Id { get; set; }

        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        //------------
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
