using Games_Library.Models;
namespace Games_Library.ViewModel
{
    public class ReviewGameVM
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int ReviewId { get; set; }
        public Game Game { get; set; }
        public Review Review { get; set; }
        public List<Review> Reviews { get; set; }
        public User User { get; set; }
    }
}
