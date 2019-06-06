using AutoMapper;
using GiphyH.DAL.GifCommands;
using GiphyH.DAL.Entities;

namespace GiphyH.DAL.GifMapper
{
    public class CommandsToGif : Profile
    {
        public CommandsToGif()
        {
            AllowNullCollections = true;
            CreateMap<Add, Gif>();
            CreateMap<Delete, Gif>();
            CreateMap<Update, Gif>();
        }
    }
}
