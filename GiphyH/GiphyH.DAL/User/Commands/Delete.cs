using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.UserCommands
{
    public class Delete : ICommand
    {
        public int Id { get; set; }
    }
}
