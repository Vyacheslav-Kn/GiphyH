using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.UserInterfaces;
using GiphyH.DAL.UserQueries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyH.DAL.UserHandlers
{
    public class UserQueryHandler : IUserQueryHandler
    {
        private ApplicationContext _db;

        public UserQueryHandler(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<User> Find(FindById query)
        {
            return await _db.Users
                .AsNoTracking()
                .Where(u => u.Id == query.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> Find(FindByName query)
        {
            return await _db.Users
                .AsNoTracking()
                .Where(u => u.Name == query.Name)
                .FirstOrDefaultAsync();
        }
    }
}
