using Games_Library.Models;
namespace Games_Library.ViewModel
{
	public class UserGameProfileVM
	{
		public int UserId { get; set; }
		public int GameId { get; set; }
		public User User { get; set; }
		public List<Game> Games { get; set; }
		public List<UserGame> userGames { get; set; }
	}
}
