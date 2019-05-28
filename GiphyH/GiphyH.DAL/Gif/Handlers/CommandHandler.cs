using AutoMapper;
using GiphyH.DAL.GifCommands;
using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace GiphyH.DAL.GifHandlers
{
    public class CommandHandler :
        ICommandHandler<Add>,
        ICommandHandler<Update>,
        ICommandHandler<Delete>
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public CommandHandler(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task Handle(Add command)
        {
            Gif gif = _mapper.Map<Add, Gif>(command);

            _db.Gifs.Add(gif);
            await _db.SaveChangesAsync();
        }

        public async Task Handle(Update command)
        {
            Gif gif = _mapper.Map<Update, Gif>(command);

            _db.Attach(gif);
            _db.Entry(gif).Property("Title").IsModified = true;
            await _db.SaveChangesAsync();
        }

        public async Task Handle(Delete command)
        {
            Gif gif = _mapper.Map<Delete, Gif>(command);

            _db.Gifs.Remove(gif);
            await _db.SaveChangesAsync();
        }
    }
}
