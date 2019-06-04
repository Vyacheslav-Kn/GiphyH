using GiphyH.BLL.Interfaces;
using GiphyH.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Infrastructure
{
    public class EncryptFilter : IResultFilter
    {
        private ICryptoService _cryptoService;

        public EncryptFilter(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;
            if (objectResult == null) {
                return;
            }

            if (typeof(IEnumerable).IsAssignableFrom(objectResult.Value.GetType()))
            {
                if (!(objectResult.Value is IList items))
                {
                    return;
                }

                foreach (var item in items)
                {
                    foreach (var prop in item.GetType().GetProperties())
                    {
                        var attribute = prop
                            .GetCustomAttributes(typeof(IProtectAttribute), false)
                            .FirstOrDefault();

                        if (attribute != null)
                        {
                            var value = prop.GetValue(item);
                            string cipheredId = _cryptoService.EncryptId(Convert.ToInt32(value));
                            prop.SetValue(item, cipheredId);
                        }
                    }
                }
            }
            else
            {
                foreach (var prop in objectResult.Value.GetType().GetProperties())
                {
                    var attribute = prop
                        .GetCustomAttributes(typeof(IProtectAttribute), false)
                        .FirstOrDefault();

                    if (attribute != null)
                    {
                        var value = prop.GetValue(objectResult.Value);
                        string cipheredId = _cryptoService.EncryptId(Convert.ToInt32(value));
                        prop.SetValue(objectResult.Value, cipheredId);
                    }
                }
            }
        }

        public void OnResultExecuted(ResultExecutedContext context) { }
    }
}
