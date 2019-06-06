using AutoMapper;
using GiphyH.DAL.UserCommands;
using GiphyH.DAL.Entities;

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
