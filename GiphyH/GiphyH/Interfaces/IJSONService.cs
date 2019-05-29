using GiphyH.BLL.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Interfaces
{
    public interface IJSONService
    {
        JObject CreateJSONFromGif(GifDTO gif);
        JArray CreateJSONFromGifs(IEnumerable<GifDTO> gifs);
    }
}
