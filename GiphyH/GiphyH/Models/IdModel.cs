using GiphyH.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Models
{
    public class IdModel
    {
        [Encrypt]
        public int Id { get; set; }
    }
}
