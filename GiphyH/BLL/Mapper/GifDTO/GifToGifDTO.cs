using AutoMapper;
using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.BLL.Services;
using GiphyH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.BLL.MapperGifDTO
{
    public class GifToGifDTO : Profile
    {
        private readonly ICryptoService _cryptoService;

        public GifToGifDTO(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;

            AllowNullCollections = true;
            CreateMap<Gif, GifDTO>()
                .ForMember(i => i.Id, opt => opt.MapFrom(m => _cryptoService.EncryptId(m.Id)));
        }
    }
}
