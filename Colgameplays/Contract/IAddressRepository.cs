using Colgameplays.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Contract
{
   public interface IAddressRepository
    {
        Task<Address> One(int id);

        Task<Address> Add(Address address);

        Task<bool> Update(int id, Address address);

        Task<bool> Delete(int id);
    }
}
