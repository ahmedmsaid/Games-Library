using Games_Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Games_Library.Controllers
{
	public class UserGamesController : Controller
	{
		myDbContext DbContext;
		public UserGamesController(myDbContext DbContext)
		{
			this.DbContext = DbContext;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AddUserGames(int id)
		{
			int? userId = HttpContext.Session.GetInt32("UserId");

			if (userId == null)
			{
				return RedirectToAction("Login", "User");
			}

			User player = DbContext.Users.SingleOrDefault(u => u.Id == userId);

			UserGame userGame = new UserGame();

			userGame.UserId = player.Id;
			userGame.GameId = id;

			DbContext.UserGames.Add(userGame);
			DbContext.SaveChanges();


			return RedirectToAction("Profile", "User");
		}
	}
}
