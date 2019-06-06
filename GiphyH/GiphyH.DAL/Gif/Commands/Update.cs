using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.GifCommands
{
    public class Update : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
