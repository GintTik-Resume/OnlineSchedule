using Microsoft.AspNetCore.Mvc;

namespace OnlineSchedule.Controllers 
{
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            return View();
        }

        public IActionResult Add() 
        {
            return View();
        }
    }
}