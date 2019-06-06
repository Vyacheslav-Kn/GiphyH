using GiphyH.DAL.Entities;
using GiphyH.DAL.GifQueries;
using GiphyH.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiphyH.DAL.GifInterfaces
{
    public interface IGifQueryHandler :
        IQueryHandler<FindById, Task<Gif>>,
        IQueryHandler<FindByTitle, Task<IEnumerable<Gif>>>,
        IQueryHandler<FindByTag, Task<IEnumerable<Gif>>>
    {

    }
}
