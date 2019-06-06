using GiphyH.DAL.Interfaces;
using GiphyH.DAL.UserCommands;

namespace GiphyH.DAL.UserInterfaces
{
    public interface IUserCommandHandler :
        ICommandHandler<Add>,
        ICommandHandler<Delete>
    {

    }
}
