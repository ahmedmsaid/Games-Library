using Microsoft.AspNetCore.Mvc;
using Games_Library.Models;
using Games_Library.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Games_Library.Controllers
{
    public class UserController : Controller
    {
        myDbContext DbContext;
        public UserController(myDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, IFormFile Avatar)
        {
            if (user == null)
            {
                return View("myError");
            }
            if (Avatar != null)
            {
                string path = $"wwwroot/img/{Avatar.FileName}";

                FileStream fs = new FileStream(path, FileMode.Create);

                Avatar.CopyTo(fs);

                user.Avatar = $"/img/{Avatar.FileName}";
            }
            else
            {
                user.Avatar = $"/img/avatar.jpg";
            }
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
     
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginVM loginvm = new LoginVM();
            return View(loginvm);
        }

        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            User user = DbContext.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (user == null)
            {
                LoginVM loginvm = new LoginVM();
                loginvm.Message = "Wrong Email or Password";
                return View("Login", loginvm);
            }
            HttpContext.Session.SetInt32("UserId", user.Id);
            return RedirectToAction("Profile");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult profile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }
            UserGameProfileVM vm = new UserGameProfileVM();
            User currentUser = DbContext.Users.Where(u => u.Id == userId).SingleOrDefault();
            currentUser.IsActive = true;
            vm.User = currentUser;
            vm.Games = DbContext.Games.ToList();
            vm.userGames = DbContext.UserGames.ToList();
            return View(vm);
        }

        public IActionResult Update(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Login");
            }
            User user = DbContext.Users.SingleOrDefault(c => c.Id == id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user, IFormFile Avatar)
        {
            User OldUser = DbContext.Users.SingleOrDefault(c => c.Id == user.Id);

            string check = $"wwwroot{OldUser.Avatar}";

            string path = $"wwwroot/img/{Avatar.FileName}";

            if (check != path) { 

                 FileStream fs = new FileStream(path, FileMode.Create);

                 Avatar.CopyTo(fs);

                 user.Avatar = $"/img/{Avatar.FileName}";

            }

            OldUser.Name = user.Name;
            OldUser.Nickname = user.Nickname;
            OldUser.Age = user.Age;
            OldUser.Country = user.Country;
            OldUser.PhoneNumber = user.PhoneNumber;
            OldUser.Avatar = user.Avatar;
            

            DbContext.SaveChanges();
            return RedirectToAction("Profile");
        }
    }
}
