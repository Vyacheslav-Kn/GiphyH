using GiphyH.BLL.DTO;
using Microsoft.AspNetCore.Http;

namespace GiphyH.Models
{
    public class GifPostModel
    {
        public IFormFile File { get; set; }
        public GifDTO Gif { get; set; }
    }
}
