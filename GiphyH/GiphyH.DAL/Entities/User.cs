using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<Gif> Gifs { get; set; } = new List<Gif>();
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
