using Colgameplays.Contract;
using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class CategoryRepositry: ICategoryRepositry
    {
        private readonly ColgameplaysContext _context;

        public CategoryRepositry(ColgameplaysContext context)
        {
            _context = context;
        }


        public async Task<List<Category>> GetallAsyn()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetOneAsyn(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Category>> SearchAsyn(string search)
        {
            return await _context.Categories.Where(x => x.Name.Contains(search)).ToListAsync();
        }

        public async Task<Category> Add(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> Update(int id, Category category)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            data.Name = category.Name;
            data.Description = category.Description;

            _context.Categories.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : true);
        }

        public async Task<bool> Delete(int id)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            _context.Categories.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }
    }
}
