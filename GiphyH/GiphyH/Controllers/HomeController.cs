using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GiphyH.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GiphyH.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGifService _gifService;
        private readonly IMapper _mapper;

        public HomeController(IGifService gifService, IMapper mapper)
        {
            _gifService = gifService;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            var c = _gifService.GetChunk("giph", 0);
            return View();
        }
    }
}
