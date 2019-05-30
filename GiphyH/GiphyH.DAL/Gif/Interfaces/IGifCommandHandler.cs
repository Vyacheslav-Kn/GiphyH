using GiphyH.DAL.GifCommands;
using GiphyH.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.GifInterfaces
{
    public interface IGifCommandHandler :
        ICommandHandler<Add>,
        ICommandHandler<Update>,
        ICommandHandler<Delete>
    {

    }
}
