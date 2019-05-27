using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<GifDTO> Gifs { get; set; } = new List<GifDTO>();
    }
}
