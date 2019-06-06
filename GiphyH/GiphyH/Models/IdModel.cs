using GiphyH.BLL.Infrastructure;

namespace GiphyH.Models
{
    public class IdModel
    {
        [Encrypt]
        public int Id { get; set; }
    }
}
