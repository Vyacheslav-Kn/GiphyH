using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.GifQueries
{
    public class FindByTitle : IQuery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; } = 5;
    }
}
