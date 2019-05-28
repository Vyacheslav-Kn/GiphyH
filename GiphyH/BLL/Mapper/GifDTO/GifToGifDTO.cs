using AutoMapper;
using GiphyH.BLL.DTO;
using GiphyH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.BLL.MapperGifDTO
{
    public class GifToGifDTO : Profile
    {
        public GifToGifDTO()
        {
            AllowNullCollections = true;
            CreateMap<Gif, GifDTO>();
        }
    }
}
