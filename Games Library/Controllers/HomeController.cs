using Games_Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Games_Library.Models;
using Games_Library.ViewModel;

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
            UserGameVM vm = new UserGameVM();
            vm.Users = DbContext.Users.ToList();
            vm.Games = DbContext.Games.ToList();

            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}