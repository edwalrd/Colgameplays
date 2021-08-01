using Colgameplays.Contract;
using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class BrandRepository: IBrandRepository
    {
        private readonly ColgameplaysContext _context;

        public BrandRepository(ColgameplaysContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetallAsyn()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetOneAsyn(int id)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Brand>> SearchAsyn(string search)
        {
            return await _context.Brands.Where(x => x.Name.Contains(search)).ToListAsync();
        }

        public async Task<Brand> Add (Brand brand)
        {
            _context.Brands.Add(brand);

            await _context.SaveChangesAsync();

            return brand;
        }

        public async Task<bool> Update (int id, Brand brand)
        {
            var data =  await GetOneAsyn(id);

            if (data == null) return false;

            data.Name = brand.Name;
            data.ModifiedDate = DateTime.Now;

            _context.Brands.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : true);
        }

        public async Task<bool> Delete(int id)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            _context.Brands.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }
    }
}
