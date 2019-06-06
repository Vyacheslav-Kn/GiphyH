using System.Threading.Tasks;

namespace GiphyH.DAL.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}
