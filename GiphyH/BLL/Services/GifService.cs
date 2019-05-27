using AutoMapper;
using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.GifCommands;
using GiphyH.DAL.GifHandlers;
using GiphyH.DAL.GifInterfaces;
using GiphyH.DAL.GifQueries;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.BLL.Services
{
    public class GifService : IGifService
    {
        private readonly CommandHandler _commandHandler;
        private readonly QueryHandler _queryHandler;
        private readonly IMapper _mapper;

        public GifService(IGifHandler gifHandler, IMapper mapper)
        {
            _commandHandler = gifHandler.CommandHandler;
            _queryHandler = gifHandler.QueryHandler;
            _mapper = mapper;
        }

        public IEnumerable<GifDTO> GetChunk(string title, int offset, int limit)
        {
            IEnumerable<Gif> gifs = _queryHandler.Find(new FindByTitle {
                Title = title,
                Offset = offset,
                Limit = limit
            });

            return _mapper.Map<IEnumerable<Gif>, IEnumerable<GifDTO>>(gifs);
        }

        public GifDTO GetById(int id)
        {
            Gif gif = _queryHandler.Find(new FindById {
                Id = id
            });

            return _mapper.Map<Gif, GifDTO>(gif);
        }

        public IEnumerable<GifDTO> GetByTag(string tagTitle)
        {
            IEnumerable<Gif> gifs = _queryHandler.Find(new FindByTag {
                TagTitle = tagTitle
            });

            return _mapper.Map<IEnumerable<Gif>, IEnumerable<GifDTO>>(gifs);
        }

        public void Add(GifDTO gif)
        {
            Add addCommand = _mapper.Map<GifDTO, Add>(gif);

            _commandHandler.Handle(addCommand);
        }

        public void Update(GifDTO gif)
        {
            Update updateCommand = _mapper.Map<GifDTO, Update>(gif);

            _commandHandler.Handle(updateCommand);
        }

        public void Delete(int id)
        {
            _commandHandler.Handle(new Delete {
                Id = id
            });
        }
    }
}
