namespace GiphyH.DAL.Entities
{
    public class GifTag
    {
        public int Id { get; set; }
        public int GifId { get; set; }
        public Gif Gif { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
