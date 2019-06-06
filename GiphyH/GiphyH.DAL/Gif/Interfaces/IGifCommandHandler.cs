using GiphyH.DAL.GifCommands;
using GiphyH.DAL.Interfaces;

namespace GiphyH.DAL.GifInterfaces
{
    public interface IGifCommandHandler :
        ICommandHandler<Add>,
        ICommandHandler<Update>,
        ICommandHandler<Delete>
    {

    }
}
