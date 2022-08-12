using Microsoft.AspNetCore.Mvc;

namespace OnlineSchedule.Controllers
{
    public class AdminController : Controller 
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }
    }
}