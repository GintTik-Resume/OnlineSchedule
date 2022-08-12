using Microsoft.AspNetCore.Mvc;

namespace OnlineSchedule.Controllers
{
    public class HistoryController : Controller 
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}