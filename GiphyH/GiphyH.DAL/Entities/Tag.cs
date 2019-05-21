using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<GifTag> GifTags { get; set; }

        public Tag()
        {
            GifTags = new List<GifTag>(); 
        }
    }
}
