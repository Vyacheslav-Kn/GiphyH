using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyH.Infrastructure
{
    public class GifOutputFormatter : TextOutputFormatter
    {
        private readonly ICryptoService _cryptoService;

        public GifOutputFormatter(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("json/gif"));
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding encoding)
        {
            HttpResponse response = context.HttpContext.Response;
            IEnumerable<GifDTO> gifs = context.Object as IEnumerable<GifDTO>;

            if (gifs != null)
            {
                JArray gifsJSON = CreateJSONFromGifs(gifs);

                await response.WriteAsync("gifsJSON");
            }
            else
            {
                GifDTO gif = context.Object as GifDTO;

                JObject gifJSON = CreateJSONFromGif(gif);

                await response.WriteAsync("gifJSON");
            }
        }

        private JObject CreateJSONFromGif(GifDTO gif)
        {
            JObject gifJSON = new JObject(
                new JProperty("Id", _cryptoService.EncryptId(gif.Id)),
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
                    new JProperty("Tags", new JArray(gif.Tags))
                );
            }

            return gifJSON;
        }

        private JArray CreateJSONFromGifs(IEnumerable<GifDTO> gifs)
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
