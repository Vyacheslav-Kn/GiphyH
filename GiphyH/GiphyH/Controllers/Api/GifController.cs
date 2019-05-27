using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiphyH.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GifController : ControllerBase
    {
        private readonly IGifService _gifService;

        public GifController(IGifService gifService)
        {
            _gifService = gifService;
        }

        // GET: api/Gif
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Gif/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Gif
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Gif/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
