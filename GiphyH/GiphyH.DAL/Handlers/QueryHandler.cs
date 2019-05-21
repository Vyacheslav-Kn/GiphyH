using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.Queries.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiphyH.DAL.Handlers
{
    public class QueryHandler :
        IQueryHandler<FindUserByPublicId, User>,
        IQueryHandler<FindUserByName, User>
    {
        private ApplicationContext _db;

        public QueryHandler(ApplicationContext db)
        {
            this._db = db;
        }

        public User Find(FindUserByPublicId query)
        {
            return _db.Users.Where(u => u.Id == query.Id).FirstOrDefault();
        }

        public User Find(FindUserByName query)
        {
            return _db.Users.Where(u => u.Name == query.Name).FirstOrDefault();
        }
    }
}
