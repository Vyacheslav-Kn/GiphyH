using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiphyH.BLL.DTO;
using GiphyH.BLL.Interfaces;
using GiphyH.Interfaces;
using GiphyH.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GiphyH.Controllers.Api
{
    [Route("api/gif")]
    [ApiController]
    public class GifController : ControllerBase
    {
        private readonly IGifService _gifService;
        private readonly ICryptoService _cryptoService;
        private readonly IJSONService _jsonService;
        private readonly IFileService _fileService;

        public GifController(IGifService gifService, ICryptoService cryptoService,
            IJSONService jsonService, IFileService fileService)
        {
            _gifService = gifService;
            _cryptoService = cryptoService;
            _jsonService = jsonService;
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

            //JArray gifsJSON = _jsonService.CreateJSONFromGifs(gifs);

            return Ok(gifs);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            int decryptedId = _cryptoService.DecryptId(id);

            GifDTO gif = await _gifService.GetById(decryptedId);

            if (gif == null)
            {
                return NotFound();
            }

            //JObject gifJSON = _jsonService.CreateJSONFromGif(gif);

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
        public async Task<IActionResult> Put(string id, [FromForm]GifDTO gif)
        {
            int decryptedId = _cryptoService.DecryptId(id);

            GifDTO savedGif = await _gifService.GetById(decryptedId);

            if (savedGif == null)
            {
                return NotFound();
            }

            gif.Id = id;

            await _gifService.Update(gif);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            int decryptedId = _cryptoService.DecryptId(id);

            GifDTO gif = await _gifService.GetById(decryptedId);

            if (gif == null)
            {
                return NotFound();
            }

            await _gifService.Delete(decryptedId);

            return NoContent();
        }
    }
}
