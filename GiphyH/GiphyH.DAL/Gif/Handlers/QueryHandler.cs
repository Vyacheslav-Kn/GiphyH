using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.GifQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiphyH.DAL.GifHandlers
{
    public class QueryHandler :
        IQueryHandler<FindById, Gif>,
        IQueryHandler<FindByTitle, IEnumerable<Gif>>,
        IQueryHandler<FindByTag, IEnumerable<Gif>>
    {
        private ApplicationContext _db;

        public QueryHandler(ApplicationContext db)
        {
            _db = db;
        }

        public Gif Find(FindById query)
        {
            return _db.Gifs
                .Include(g => g.User)
                .Include(g => g.GifTags)
                .ThenInclude(gt => gt.Tag)
                .Where(g => g.Id == query.Id)
                .FirstOrDefault();
        }

        public IEnumerable<Gif> Find(FindByTitle query)
        {
            return _db.Gifs
                .Where(g => g.Title == query.Title)
                .Skip(query.Offset)
                .Take(query.Limit)
                .ToList();
        }

        public IEnumerable<Gif> Find(FindByTag query)
        {
            return _db.Gifs
                .Include(g => g.GifTags)
                .ThenInclude(gt => gt.Tag)
                .Where(g => g.GifTags.Any(gt => gt.Tag.Title == query.TagTitle))
                .ToList();
        }
    }
}
