using AutoMapper;
using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.DAL.Entities;
using GiphyH.DAL.GifCommands;
using GiphyH.DAL.GifInterfaces;
using GiphyH.DAL.GifQueries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiphyH.BLL.Services
{
    public class GifService : IGifService
    {
        private readonly IGifCommandHandler _commandHandler;
        private readonly IGifQueryHandler _queryHandler;
        private readonly IMapper _mapper;

        public GifService(IGifCommandHandler commandHandler, IGifQueryHandler queryHandler, IMapper mapper)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GifDTO>> GetChunk(string title, int offset, int limit)
        {
            IEnumerable<Gif> gifs = await _queryHandler.Find(new FindByTitle {
                Title = title,
                Offset = offset,
                Limit = limit
            });

            return _mapper.Map<IEnumerable<Gif>, IEnumerable<GifDTO>>(gifs);
        }

        public async Task<GifDTO> GetById(int id)
        {
            Gif gif = await _queryHandler.Find(new FindById {
                Id = id
            });

            return _mapper.Map<Gif, GifDTO>(gif);
        }

        public async Task<IEnumerable<GifDTO>> GetByTag(string tagTitle)
        {
            IEnumerable<Gif> gifs = await _queryHandler.Find(new FindByTag {
                TagTitle = tagTitle
            });

            return _mapper.Map<IEnumerable<Gif>, IEnumerable<GifDTO>>(gifs);
        }

        public async Task Add(GifDTO gif)
        {
            Add addCommand = _mapper.Map<GifDTO, Add>(gif);
            addCommand.PublicationDate = DateTime.Now;

            await _commandHandler.Handle(addCommand);
        }

        public async Task Update(GifDTO gif)
        {
            Update updateCommand = _mapper.Map<GifDTO, Update>(gif);

            await _commandHandler.Handle(updateCommand);
        }

        public async Task Delete(int id)
        {
            await _commandHandler.Handle(new Delete {
                Id = id
            });
        }
    }
}
