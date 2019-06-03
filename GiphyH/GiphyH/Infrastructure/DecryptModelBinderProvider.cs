using GiphyH.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Infrastructure
{
    public class DecryptModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.IsComplexType) return null;

            string propertyName = context.Metadata.PropertyName;
            if (propertyName == null) return null;

            var propertyInfo = context.Metadata.ContainerType.GetProperty(propertyName);
            if (propertyInfo == null) return null;

            var encryptAttribute = propertyInfo
                .GetCustomAttributes(typeof(IDecryptAttribute), false)
                .FirstOrDefault();
            if (encryptAttribute == null) return null;

            return new BinderTypeModelBinder(typeof(DecryptModelBinder));
        }
    }
}
