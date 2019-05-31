using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Infrastructure
{
    public class IdInputMiddleware
    {
        private readonly RequestDelegate _next;
        private ICryptoService _cryptoService;

        public IdInputMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            IServiceProvider serviceProvider = context.RequestServices;
            _cryptoService = serviceProvider.GetService(typeof(ICryptoService)) as ICryptoService;

            int decryptedId = _cryptoService.DecryptId(context.Request.Query["id"]);

            var parsedParams = QueryHelpers.ParseQuery(context.Request.QueryString.ToString());
            var keyValuePairs = parsedParams.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();

            keyValuePairs.RemoveAll(x => x.Key == "id");

            QueryBuilder queryBuilder = new QueryBuilder(keyValuePairs);
            queryBuilder.Add("id", decryptedId.ToString());
            context.Request.QueryString = queryBuilder.ToQueryString();

            await _next.Invoke(context);
        }
    }
}
