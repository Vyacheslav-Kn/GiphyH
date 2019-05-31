using GiphyH.BLL.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Models
{
    public class GifPostModel
    {
        public IFormFile File { get; set; }
        public GifDTO Gif { get; set; }
    }
}
