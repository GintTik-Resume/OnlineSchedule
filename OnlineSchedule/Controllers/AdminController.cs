using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineSchedule.BusinessLogic.History;
using OnlineSchedule.BusinessLogic.Mappers;
using OnlineSchedule.BusinessLogic.Services;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller 
    {
        private readonly UserService _userService;
        private readonly Mapper _mapper;
        private readonly HistoryLogger _logger;

        public AdminController(UserService userService, Mapper mapper, HistoryLogger logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = _userService.GetUsers();
            var models = _mapper.MapUsersToUserShortDatas(users, _userService);

            return View(models);
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _mapper.Map<User>(model);
            var result = await _userService.TryCreateUser(user, model.Password, model.Role);

            if (result.Succeeded)
            {
                var performer = _userService.GetUser(HttpContext.User);
                _logger.LogUser(performer.Id, user.Id, "add");
                return RedirectToAction("Index");
            }

            AddErrors(result.Errors);
            return View(model);
        }


        private void AddErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
                ModelState.AddModelError(string.Empty, item.Description);
        }
    }
}