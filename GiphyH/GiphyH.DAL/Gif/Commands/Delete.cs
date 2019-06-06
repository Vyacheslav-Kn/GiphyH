using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.GifCommands
{
    public class Delete : ICommand
    {
        public int Id { get; set; }
    }
}
