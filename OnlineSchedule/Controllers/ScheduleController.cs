using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.Controllers 
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _rep;
        private readonly Mapper _mapper;

        public ScheduleController(IScheduleRepository rep, Mapper mapper)
        {
            _rep = rep;
            _mapper = mapper;
        }

        public IActionResult Index(Guid id)
        {
            if (id == Guid.Empty)
                return View();

            Schedule schedule = _rep.Get(id);
            if (schedule == null)
                return NotFound(); 
            return View(schedule);
        }

        public IActionResult All()
        {
            //var schedules = _schedules.GetByUser();
            return View();
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddScheduleViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var schedule = _mapper.Map<Schedule>(model);
            schedule.Id = Guid.NewGuid();

            _rep.Add(schedule);
            return RedirectToAction("Index", new { id = schedule.Id });
        }
    }
}