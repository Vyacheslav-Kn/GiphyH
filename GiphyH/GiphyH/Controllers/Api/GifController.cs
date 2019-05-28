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
    [Route("api/gif")]
    [ApiController]
    public class GifController : ControllerBase
    {
        private readonly IGifService _gifService;

        public GifController(IGifService gifService)
        {
            _gifService = gifService;
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
        public async Task<IActionResult> Get(int id)
        {
            GifDTO gif = await _gifService.GetById(id);

            if (gif == null)
            {
                return NotFound();
            }

            return Ok(gif);
        }

        // POST: api/Gif
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, string title)
        {
            GifDTO gif = await _gifService.GetById(id);

            if (gif == null)
            {
                return NotFound();
            }

            await _gifService.Update(new GifDTO {
                Id = id,
                Title = title
            });

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            GifDTO gif = await _gifService.GetById(id);

            if (gif == null)
            {
                return NotFound();
            }

            await _gifService.Delete(id);

            return NoContent();
        }
    }
}
