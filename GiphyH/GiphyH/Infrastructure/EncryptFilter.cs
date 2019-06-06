using GiphyH.BLL.Infrastructure;
using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;

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
            if (!(context.Result is ObjectResult objectResult))
            {
                return;
            }

            if (typeof(IEnumerable).IsAssignableFrom(objectResult.Value.GetType()))
            {
                if (!(objectResult.Value is IEnumerable items))
                {
                    return;
                }

                foreach (object item in items)
                {
                    EncryptIdProperty(item);
                }
            }
            else
            {
                EncryptIdProperty(objectResult.Value);
            }
        }

        public void OnResultExecuted(ResultExecutedContext context) { }

        private void EncryptIdProperty(object model)
        {
            foreach (PropertyInfo prop in model.GetType().GetProperties())
            {
                object attribute = prop
                    .GetCustomAttributes(typeof(EncryptAttribute), false)
                    .FirstOrDefault();

                if (attribute != null)
                {
                    object value = prop.GetValue(model);
                    string cipheredId = _cryptoService.EncryptId(Convert.ToInt32(value));
                    prop.SetValue(model, cipheredId);
                }
            }
        }
    }
}
