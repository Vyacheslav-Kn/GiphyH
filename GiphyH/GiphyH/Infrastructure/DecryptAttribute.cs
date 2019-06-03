using GiphyH.BLL.Interfaces;
using GiphyH.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Infrastructure
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class DecryptAttribute : Attribute, IDecryptAttribute { }
}
