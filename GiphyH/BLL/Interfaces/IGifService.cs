using GiphyH.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.BLL.Interfaces
{
    public interface IGifService
    {
        IEnumerable<GifDTO> GetChunk(string title, int offset, int limit = 5);

        GifDTO GetById(int id);

        IEnumerable<GifDTO> GetByTag(string tagTitle);

        void Add(GifDTO gif);

        void Update(GifDTO gif);
    }
}
