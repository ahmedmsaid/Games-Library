using Microsoft.AspNetCore.Mvc;
using Games_Library.Models;
using Games_Library.ViewModel;
namespace Games_Library.Controllers
{
    public class ReviewController : Controller
    {

        myDbContext DbContext;
        public ReviewController(myDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public IActionResult Index(int id)
        {
            int? userID = HttpContext.Session.GetInt32("UserId");
            ReviewGameVM vm = new ReviewGameVM();
            vm.GameId = id;
            vm.User = DbContext.Users.SingleOrDefault(u => u.Id == userID);
            vm.Game = DbContext.Games.SingleOrDefault(g => g.Id == id);
            vm.Reviews = DbContext.Reviews.ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddReview(ReviewGameVM reviewgame)
        {
           
           Review review = reviewgame.Review;

            review.UserId = reviewgame.UserId;
            review.GameId = reviewgame.GameId;

            DbContext.Reviews.Add(review);
            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
