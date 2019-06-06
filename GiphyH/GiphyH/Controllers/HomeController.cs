using Microsoft.AspNetCore.Mvc;

namespace GiphyH.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
