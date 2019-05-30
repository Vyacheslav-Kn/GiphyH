using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Services
{
    public class JSONService : IJSONService
    {
        private readonly ICryptoService _cryptoService;

        public JSONService(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public JObject CreateJSONFromGif(GifDTO gif)
        {
            JObject gifJSON = new JObject(
                //new JProperty("Id", _cryptoService.EncryptId(gif.Id)),
                new JProperty("Title", gif.Title),
                new JProperty("PublicationDate", gif.PublicationDate),
                new JProperty("ImageUrl", gif.ImageUrl)
            );

            if (gif.User != null)
            {
                gifJSON.Add(
                    new JProperty("User", new JObject(
                        new JProperty("Name", gif.User.Name),
                        new JProperty("AvatarUrl", gif.User.AvatarUrl)
                    ))
                );
            }

            if (gif.Tags.Count() > 0)
            {
                gifJSON.Add(
                    new JProperty("Tags", new JArray(
                        gif.Tags.Select(gt => new JObject(
                            new JProperty("Title", gt.Title)
                        ))
                    ))
                );
            }

            return gifJSON;
        }

        public JArray CreateJSONFromGifs(IEnumerable<GifDTO> gifs)
        {
            List<JObject> individualGifsJSON = new List<JObject>();

            foreach (GifDTO gif in gifs)
            {
                individualGifsJSON.Add(CreateJSONFromGif(gif));
            }

            JArray gifsJSON = new JArray(individualGifsJSON);

            return gifsJSON;
        }
    }
}
