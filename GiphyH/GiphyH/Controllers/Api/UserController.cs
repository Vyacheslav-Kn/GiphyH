using System.Threading.Tasks;
using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GiphyH.Controllers.Api
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
        public async Task<IActionResult> Delete([ModelBinder(typeof(DecryptModelBinder))]int id)
        {
            UserDTO user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.Delete(id);

            return NoContent();
        }
    }
}
