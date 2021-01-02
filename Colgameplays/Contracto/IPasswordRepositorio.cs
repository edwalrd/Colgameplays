using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contracto
{
   public interface IPasswordRepositorio
    {
        string Hash(string password);

        bool Check(string hash, string password);
    }
}
