using Colgameplays.Contract;
using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class ConsolesRepository: IConsolesRepository
    {
        private readonly ColgameplaysContext _context;

        public ConsolesRepository(ColgameplaysContext context)
        {
            _context = context;
        }

        public async Task<List<Consoles>> GetallAsyn()
        {
            return await _context.Consoles.ToListAsync();
        }

        public async Task<Consoles> GetOneAsyn(int id)
        {
            return await _context.Consoles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Consoles>> SearchAsyn(string search)
        {
            return await _context.Consoles.Where(x => x.Name.Contains(search)).ToListAsync();
        }

        public async Task<Consoles> Add(Consoles consoles)
        {

            _context.Consoles.Add(consoles);

            await _context.SaveChangesAsync();

            return consoles;
        }

        public async Task<bool> Update(int id, Consoles consoles)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            data.Name = consoles.Name;
            data.IdBrand = consoles.IdBrand;
            data.ModifiedDate = DateTime.Now;

            _context.Consoles.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : true);
        }

        public async Task<bool> Delete(int id)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            _context.Consoles.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }
    }
}
