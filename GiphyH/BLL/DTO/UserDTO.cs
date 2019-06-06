using GiphyH.BLL.Infrastructure;
using GiphyH.BLL.PublicDTO;

namespace GiphyH.BLL.DTO
{
    public class UserDTO : UserPublicDTO
    {
        [Encrypt]
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
