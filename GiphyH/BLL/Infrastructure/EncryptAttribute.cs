using System;

namespace GiphyH.BLL.Infrastructure
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class EncryptAttribute : Attribute { }
}
