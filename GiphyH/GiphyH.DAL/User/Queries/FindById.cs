using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.UserQueries
{
    public class FindById : IQuery
    {
        public int Id { get; set; }
    }
}
