using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.GifQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiphyH.DAL.GifInterfaces;

namespace GiphyH.DAL.GifHandlers
{
    public class GifQueryHandler : IGifQueryHandler
    {
        private ApplicationContext _db;

        public GifQueryHandler(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Gif> Find(FindById query)
        {
           return await _db.Gifs
                .AsNoTracking()
                .Include(g => g.User)
                .Include(g => g.GifTags)
                .ThenInclude(gt => gt.Tag)
                .Where(g => g.Id == query.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Gif>> Find(FindByTitle query)
        {
            return await _db.Gifs
                .AsNoTracking()
                .Where(g => g.Title == query.Title)
                .Skip(query.Offset)
                .Take(query.Limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gif>> Find(FindByTag query)
        {
            return await _db.Gifs
                .AsNoTracking()
                .Include(g => g.GifTags)
                .ThenInclude(gt => gt.Tag)
                .Where(g => g.GifTags.Any(gt => gt.Tag.Title == query.TagTitle))
                .ToListAsync();
        }
    }
}
