using Games_Library.Models;
namespace Games_Library.ViewModel
{
	public class UserGameVM
	{
		public int UserId { get; set; }
		public int GameId { get; set; }
		public List<User> Users { get; set; }
		public List<Game> Games { get; set; }
	}
}
