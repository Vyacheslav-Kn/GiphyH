using GiphyH.BLL.DTO;
using System.Threading.Tasks;

namespace GiphyH.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetById(int id);

        Task<UserDTO> GetByName(string name);

        Task Add(UserDTO user);

        Task Delete(int id);
    }
}
