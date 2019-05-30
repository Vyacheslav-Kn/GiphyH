using GiphyH.BLL.PublicDTO;
using GiphyH.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.BLL.DTO
{
    public class GifDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImageUrl { get; set; }
        public UserPublicDTO User { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; } = new List<TagDTO>();
    }
}
