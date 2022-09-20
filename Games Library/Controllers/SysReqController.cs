using Microsoft.AspNetCore.Mvc;
using Games_Library.Models;
using Games_Library.ViewModel;
namespace Games_Library.Controllers
{
    public class SysReqController : Controller
    {

        myDbContext DbContext;
        public SysReqController(myDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddSysReq()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(GameSysReq fullgame)
        {
            SysReq sysreq = fullgame.SysReq;

            DbContext.SysReqs.Add(sysreq);
            DbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
