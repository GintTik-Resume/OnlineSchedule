using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineSchedule.BusinessLogic.Authenticate;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.Controllers
{
    public class AuthController : Controller 
    {
        private readonly Authenticator _authenticator;
        private readonly Mapper _mapper;

        public AuthController(Authenticator authenticator, Mapper mapper)
        {
            _authenticator = authenticator;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            if (_authenticator.IsAuthorized(HttpContext.User))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _mapper.Map<User>(model);

            var loginResult = _authenticator.TryLogin(user, model.Password, model.RememberMe);
            if (loginResult.Successfully == false)
            {
                SetModelStateErrors(loginResult.Errors);
                return View(model);
            }

            return RedirectToAction("All", "Schedule");
        }

        public IActionResult Registration()
        {
            if (_authenticator.IsAuthorized(HttpContext.User))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = _mapper.Map<User>(model);
            var registrationResult = _authenticator.TryRegistration(user, model.Password, model.RememberMe);
            if (registrationResult.Successfully == false)
            {
                SetModelStateErrors(registrationResult.Errors);
                return View(model);
            }

            return RedirectToAction("All", "Schedule");
        }

        public IActionResult Logout()
        {
            _authenticator.Logout();
            return RedirectToAction("Login");
        }

        public void SetModelStateErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
        }
    }
}