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
        public User Find(FindUserByPublicId query)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.Where(u => u.PublicId == query.PublicId).FirstOrDefault();
            }
        }

        public User Find(FindUserByName query)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Users.Where(u => u.Name == query.Name).FirstOrDefault();
            }
        }
    }
}
