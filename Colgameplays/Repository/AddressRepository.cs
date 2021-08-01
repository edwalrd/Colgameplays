using Colgameplays.Contract;
using Colgameplays.Entities;
using Colgameplays.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ColgameplaysContext _context;

        public AddressRepository(ColgameplaysContext  context)
        {
            _context = context;
        }


        public async Task<Address> One (int id)
        {
            return await _context.Addres.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address> Add(Address address)
        {
            _context.Addres.Add(address);

            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<bool> Update(int id, Address address)
        {
            var data = await _context.Addres.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            data.Ciudad = address.Ciudad;
            data.Direccion = address.Direccion;
            data.Telefono = address.Telefono;
            data.IdUser = address.IdUser;

            _context.Addres.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : true);
        }

        public async Task<bool> Delete(int id)
        {
            var data = await _context.Addres.FirstOrDefaultAsync(x => x.Id == id);

            if (data == null) return false;

            _context.Addres.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }

    }
}
