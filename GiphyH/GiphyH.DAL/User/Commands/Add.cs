using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.UserCommands
{
    public class Add : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string AvatarUrl { get; set; }
    }
}
