using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.UserQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiphyH.DAL.UserHandlers
{
    public class QueryHandler :
        IQueryHandler<FindById, User>,
        IQueryHandler<FindByName, User>
    {
        private ApplicationContext _db;

        public QueryHandler(ApplicationContext db)
        {
            _db = db;
        }

        public User Find(FindById query)
        {
            return _db.Users.Where(u => u.Id == query.Id).FirstOrDefault();
        }

        public User Find(FindByName query)
        {
            return _db.Users.Where(u => u.Name == query.Name).FirstOrDefault();
        }
    }
}
