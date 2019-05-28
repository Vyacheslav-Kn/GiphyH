using AutoMapper;
using GiphyH.BLL.DTO;
using GiphyH.DAL.Entities;

namespace GiphyH.BLL.MapperUserDTO
{
    public class UserToUserDTO : Profile
    {
        public UserToUserDTO()
        {
            AllowNullCollections = true;
            CreateMap<User, UserDTO>();
        }
    }
}
