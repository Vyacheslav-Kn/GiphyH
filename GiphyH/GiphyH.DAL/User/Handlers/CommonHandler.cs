﻿using AutoMapper;
using GiphyH.DAL.Database;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.UserHandlers;
using GiphyH.DAL.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserHandlers
{
    public class CommonHandler : ICommonHandler
    {
        public CommandHandler CommandHandler { get; set; }
        public QueryHandler QueryHandler { get; set; }

        public CommonHandler(ApplicationContext db, IMapper mapper)
        {
            CommandHandler = new CommandHandler(db, mapper);
            QueryHandler = new QueryHandler(db);
        }
    }
}
