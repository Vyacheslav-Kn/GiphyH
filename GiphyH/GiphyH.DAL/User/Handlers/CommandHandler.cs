using AutoMapper;
using GiphyH.DAL.UserCommands;
using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserHandlers
{
    public class CommandHandler :
        ICommandHandler<Add>,
        ICommandHandler<Delete>
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public CommandHandler(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Handle(Add command)
        {
            User user = _mapper.Map<Add, User>(command);

            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Handle(Delete command)
        {
            User user = _mapper.Map<Delete, User>(command);

            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
