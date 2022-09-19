using Microsoft.AspNetCore.Mvc;
using Games_Library.Models;
using Games_Library.ViewModel;

namespace Games_Library.Controllers
{
    public class GameController : Controller
    {
        myDbContext DbContext;
        public GameController(myDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddGame()
		{
            return View();
		}

        [HttpPost]
        public IActionResult AddGame(Game game, IFormFile Img)
        {
            if (game == null)
            {
                return View("myError");
            }
            if (Img != null)
            {
                string path = $"wwwroot/img/{Img.FileName}";

                FileStream fs = new FileStream(path, FileMode.Create);

                Img.CopyTo(fs);

                game.Img = $"/img/{Img.FileName}";
            }
            else
            {
                game.Img = $"/img/avatar.jpg";
            }

            DbContext.Games.Add(game);
            DbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
