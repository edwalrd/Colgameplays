using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
    public  interface IPasswordRepository
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }
}
