using GiphyH.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiphyH.BLL.Interfaces
{
    public interface IGifService
    {
        Task<IEnumerable<GifDTO>> GetChunk(string title, int offset, int limit = 5);

        Task<GifDTO> GetById(int id);

        Task<IEnumerable<GifDTO>> GetByTag(string tagTitle);

        Task Add(GifDTO gif);

        Task Update(GifDTO gif);

        Task Delete(int id);
    }
}
