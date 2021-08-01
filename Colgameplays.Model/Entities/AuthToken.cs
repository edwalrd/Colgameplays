using Colgameplays.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Model.Entities
{
   public  class AuthToken
    {
        public string Toke { get; set; }
        public User User { get; set; }
    }
}
