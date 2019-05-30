using GiphyH.DAL.Interfaces;
using GiphyH.DAL.UserCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.UserInterfaces
{
    public interface IUserCommandHandler :
        ICommandHandler<Add>,
        ICommandHandler<Delete>
    {

    }
}
