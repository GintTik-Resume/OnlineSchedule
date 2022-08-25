using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineSchedule.Data.Repositories.Interfaces;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.Controllers
{
    public class HistoryController : Controller 
    {
        private const int MinPage = 1;
        private readonly IHistoryUserRepository _historyUser;
        private readonly IHistoryScheduleRepository _historySchedule;
        private readonly Mapper _mapper;

        public HistoryController(IHistoryUserRepository historyUser, IHistoryScheduleRepository historySchedule, Mapper mapper)
        {
            _historyUser = historyUser;
            _historySchedule = historySchedule;
            _mapper = mapper;
        }

        public IActionResult Schedules(int page = MinPage)
        {
            if (page < MinPage)
                page = MinPage;

            return View(_historySchedule.GetList(page));
        }

        public IActionResult Users(int page = MinPage)
        {
            if (page < MinPage)
                page = MinPage;

            var items = _historyUser.GetList(page);
            var models = _mapper.Map<List<HistoryUserViewModel>>(items);

            return View(models);
        }
    }
}