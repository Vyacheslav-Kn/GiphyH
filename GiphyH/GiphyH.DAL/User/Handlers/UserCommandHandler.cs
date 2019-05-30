using AutoMapper;
using GiphyH.DAL.UserCommands;
using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GiphyH.DAL.UserInterfaces;

namespace GiphyH.DAL.UserHandlers
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public UserCommandHandler(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Handle(Add command)
        {
            User user = _mapper.Map<Add, User>(command);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task Handle(Delete command)
        {
            User user = _mapper.Map<Delete, User>(command);

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }
}
