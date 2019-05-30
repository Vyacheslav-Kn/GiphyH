using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiphyH.Controllers.Api
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICryptoService _cryptoService;

        public UserController(IUserService userService, ICryptoService cryptoService)
        {
            _userService = userService;
            _cryptoService = cryptoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]UserDTO user)
        {
            UserDTO registeredUser = await _userService.GetByName(user.Name);

            if (registeredUser != null)
            {
                return BadRequest();
            }

            await _userService.Add(user);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            int decryptedId = _cryptoService.DecryptId(id);

            UserDTO user = await _userService.GetById(decryptedId);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.Delete(decryptedId);

            return NoContent();
        }
    }
}
