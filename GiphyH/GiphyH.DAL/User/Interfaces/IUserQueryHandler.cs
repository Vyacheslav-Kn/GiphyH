using GiphyH.DAL.Entities;
using GiphyH.DAL.Interfaces;
using GiphyH.DAL.UserQueries;
using System.Threading.Tasks;

namespace GiphyH.DAL.UserInterfaces
{
    public interface IUserQueryHandler :
        IQueryHandler<FindById, Task<User>>,
        IQueryHandler<FindByName, Task<User>>
    {

    }
}
