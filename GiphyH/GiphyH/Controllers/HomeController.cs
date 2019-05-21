using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GiphyH.DAL.Commands.Gif;
using GiphyH.DAL.Database;
using GiphyH.DAL.Entities;
using GiphyH.DAL.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace GiphyH.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db;
        private IMapper _mapper;

        public HomeController(ApplicationContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
