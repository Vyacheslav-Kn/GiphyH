using AutoMapper;
using GiphyH.BLL.DTO;
using GiphyH.DAL.Entities;
using System.Linq;

namespace GiphyH.BLL.MapperGifDTO
{
    public class GifToGifDTO : Profile
    {
        public GifToGifDTO()
        {
            AllowNullCollections = true;
            CreateMap<Gif, GifDTO>()
                .ForMember(g => g.Tags, opt => opt.MapFrom(gd => gd.GifTags.Select(gt => gt.Tag)));
        }
    }
}
