using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiphyH.DAL.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task Handle(T command);
    }
}
