using GiphyH.BLL.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Linq;
using System.Reflection;

namespace GiphyH.Infrastructure
{
    public class DecryptModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.IsComplexType) {
                return null;
            }

            string propertyName = context.Metadata.PropertyName;
            if (propertyName == null) {
                return null;
            }

            PropertyInfo propertyInfo = context.Metadata.ContainerType.GetProperty(propertyName);
            if (propertyInfo == null)
            {
                return null;
            }

            object attribute = propertyInfo
                .GetCustomAttributes(typeof(EncryptAttribute), false)
                .FirstOrDefault();
            if (attribute == null)
            {
                return null;
            }

            return new BinderTypeModelBinder(typeof(DecryptModelBinder));
        }
    }
}
