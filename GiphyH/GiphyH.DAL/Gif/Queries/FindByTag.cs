using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.GifQueries
{
    public class FindByTag : IQuery
    {
        public int Id { get; set; }
        public string TagTitle { get; set; }
    }
}
