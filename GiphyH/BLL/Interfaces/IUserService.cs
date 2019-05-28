using GiphyH.BLL.DTO;

namespace GiphyH.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetById(int id);

        UserDTO GetByName(string name);

        void Add(UserDTO user);

        void Delete(int id);
    }
}
