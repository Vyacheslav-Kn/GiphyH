using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Entities
{
    public class Gif
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<GifTag> GifTags { get; set; }

        public Gif()
        {
            GifTags = new List<GifTag>();
        }
    }
}
