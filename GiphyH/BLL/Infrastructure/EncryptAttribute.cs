using GiphyH.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.BLL.Infrastructure
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class EncryptAttributeAttribute : Attribute, IEncryptAttribute { }
}
