using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.Infrastructure;
using GiphyH.Interfaces;
using GiphyH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyH.Controllers.Api
{
    [Route("api/gif")]
    [ApiController]
    public class GifController : ControllerBase
    {
        private readonly IGifService _gifService;
        private readonly IFileService _fileService;

        public GifController(IGifService gifService, IFileService fileService)
        {
            _gifService = gifService;
            _fileService = fileService;
        }

        [HttpGet("/api/search")]
        public async Task<IActionResult> Get(string title, int offset, int limit)
        {
            IEnumerable<GifDTO> gifs = await _gifService.GetChunk(title, offset, limit);

            if (gifs.Count() == 0)
            {
                return NotFound();
            }

            return Ok(gifs);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]IdModel model)
        {
            GifDTO gif = await _gifService.GetById(model.Id);

            if (gif == null)
            {
                return NotFound();
            }

            return Ok(gif);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]GifPostModel model)
        {
            GifDTO gif = model.Gif;

            gif.ImageUrl = await _fileService.SaveFile(model.File);
            await _gifService.Add(gif);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery]IdModel model, [FromForm]GifDTO gif)
        {
            GifDTO savedGif = await _gifService.GetById(model.Id);

            if (savedGif == null)
            {
                return NotFound();
            }

            gif.Id = savedGif.Id;
            await _gifService.Update(gif);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]IdModel model)
        {
            GifDTO gif = await _gifService.GetById(model.Id);

            if (gif == null)
            {
                return NotFound();
            }

            await _gifService.Delete(model.Id);

            return NoContent();
        }
    }
}
