using Games_Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Games_Library.Models;

namespace Games_Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        myDbContext DbContext;
        public HomeController(ILogger<HomeController> logger, myDbContext DbContext)
        {
            _logger = logger;
            this.DbContext = DbContext;
        }

        public IActionResult Index()
        {
            List<Game> games = DbContext.Games.ToList();
            return View(games);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}