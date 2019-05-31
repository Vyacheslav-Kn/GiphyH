using AutoMapper;
using GiphyH.DAL.UserCommands;
using GiphyH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserMapper
{
    public class CommandsToUser : Profile
    {
        public CommandsToUser()
        {
            AllowNullCollections = true;
            CreateMap<Add, User>();
            CreateMap<Delete, User>();
        }
    }
}
