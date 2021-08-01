using Colgameplays.Contract;
using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly ColgameplaysContext _context;

        public ArticleRepository(ColgameplaysContext context)
        {
            _context = context;
        }
        public async Task<List<Article>> GetallAsyn()
        {
            return await _context.Articles.Include(x => x.Consoles).Include(x => x.Category).ToListAsync();
        }

        public async Task<Article> GetOneAsyn(int id)
        {
            return await _context.Articles.Include(x => x.Consoles).Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Article>> SearchAsyn(string search)
        {
            return await _context.Articles.Where(x => x.Name.Contains(search)).Include(x => x.Consoles).Include(x => x.Category).ToListAsync();

        }

        public async Task<Article> Add(Article article)
        {
            _context.Articles.Add(article);

            await _context.SaveChangesAsync();

            return article;
        }

        public async Task<bool> Update(int id, Article article)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            data.Name = article.Name;
            data.Price = article.Price;
            data.Description = article.Description;
            data.LinkVideo = article.LinkVideo;
            data.Condition = article.Condition;
            data.IdConsole = article.IdConsole;
            data.IdCategory = article.IdCategory;
            data.ModifiedDate = DateTime.Now;

            _context.Articles.Update(data);

            return (await _context.SaveChangesAsync() > 0 ? true : true);
        }

        public async Task<bool> Delete(int id)
        {
            var data = await GetOneAsyn(id);

            if (data == null) return false;

            _context.Articles.Remove(data);

            return (await _context.SaveChangesAsync() > 0 ? true : false);
        }

    }
}
