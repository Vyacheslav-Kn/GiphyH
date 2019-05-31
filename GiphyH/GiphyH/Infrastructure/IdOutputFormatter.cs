using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyH.Infrastructure
{
    public class IdOutputFormatter : OutputFormatter
    {
        private ICryptoService _cryptoService;

        public IdOutputFormatter() { }

        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            Type type = context.ObjectType;

            if (type == typeof(GifDTO) || typeof(IEnumerable<GifDTO>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            IServiceProvider serviceProvider = context.HttpContext.RequestServices;
            _cryptoService = serviceProvider.GetService(typeof(ICryptoService)) as ICryptoService;

            HttpResponse response = context.HttpContext.Response;
            response.ContentType = "application/json";

            IEnumerable<GifDTO> gifs = context.Object as IEnumerable<GifDTO>;

            if (gifs != null)
            {
                int dbId = 0;

                foreach (GifDTO gif in gifs)
                {
                    dbId = Convert.ToInt32(gif.Id);
                    gif.Id = _cryptoService.EncryptId(dbId);
                }

                await response.WriteAsync(JsonConvert.SerializeObject(gifs));
            }
            else
            {
                GifDTO gif = context.Object as GifDTO;

                int dbId = Convert.ToInt32(gif.Id);
                gif.Id = _cryptoService.EncryptId(dbId);

                await response.WriteAsync(JsonConvert.SerializeObject(gif));
            }
        }
    }
}
