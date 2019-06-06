using GiphyH.BLL.Infrastructure;
using GiphyH.BLL.PublicDTO;
using System;
using System.Collections.Generic;

namespace GiphyH.BLL.DTO
{
    public class GifDTO
    {
        [Encrypt]
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImageUrl { get; set; }
        public UserPublicDTO User { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; } = new List<TagDTO>();
    }
}
