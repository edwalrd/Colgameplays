using Colgameplays.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Model
{
    public class Security
    {
        public string User { get; set; }

        public string Password { get; set; }

        public Roles role { get; set; }
    }
}
