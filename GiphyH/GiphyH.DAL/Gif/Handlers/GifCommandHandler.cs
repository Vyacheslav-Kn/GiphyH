﻿using AutoMapper;
using GiphyH.DAL.GifCommands;
using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using System.Threading.Tasks;
using GiphyH.DAL.GifInterfaces;

namespace GiphyH.DAL.GifHandlers
{
    public class GifCommandHandler : IGifCommandHandler
    {
        private ApplicationContext _db;
        private readonly IMapper _mapper;

        public GifCommandHandler(ApplicationContext db, IMapper mapper)
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
