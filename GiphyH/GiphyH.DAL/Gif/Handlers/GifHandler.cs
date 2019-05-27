using AutoMapper;
using GiphyH.DAL.Database;
using GiphyH.DAL.GifHandlers;
using GiphyH.DAL.GifInterfaces;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.GifHandlers
{
    public class GifHandler : IGifHandler
    {
        public CommandHandler CommandHandler { get; set; }
        public QueryHandler QueryHandler { get; set; }

        public GifHandler(ApplicationContext db, IMapper mapper)
        {
            CommandHandler = new CommandHandler(db, mapper);
            QueryHandler = new QueryHandler(db);
        }
    }
}
