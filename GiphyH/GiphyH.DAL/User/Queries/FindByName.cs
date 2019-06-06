using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.UserQueries
{
    public class FindByName : IQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
