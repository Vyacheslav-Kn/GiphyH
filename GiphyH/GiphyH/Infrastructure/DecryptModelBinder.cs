using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Infrastructure
{
    public class DecryptModelBinder : IModelBinder
    {
        private readonly ICryptoService _cryptoService;

        public DecryptModelBinder(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult == ValueProviderResult.None)
                return Task.CompletedTask;

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

            int decryptedId = _cryptoService.DecryptId(valueProviderResult.FirstValue);
            bindingContext.Result = ModelBindingResult.Success(decryptedId);

            return Task.CompletedTask;
        }
    }
}
