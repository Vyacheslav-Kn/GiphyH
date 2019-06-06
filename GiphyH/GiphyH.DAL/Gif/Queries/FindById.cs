using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.GifQueries
{
    public class FindById : IQuery
    {
        public int Id { get; set; }
    }
}
