using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.DAL.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
