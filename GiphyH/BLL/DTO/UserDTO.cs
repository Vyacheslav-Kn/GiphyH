using GiphyH.BLL.PublicDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiphyH.BLL.DTO
{
    public class UserDTO : UserPublicDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
