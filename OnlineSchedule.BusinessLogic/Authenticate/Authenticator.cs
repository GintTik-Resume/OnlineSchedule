using Microsoft.AspNetCore.Identity;
using OnlineSchedule.Data.Entities;
using System.Security.Claims;

namespace OnlineSchedule.BusinessLogic.Authenticate
{
    public class Authenticator
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public Authenticator(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            FillRoles();
        }
        
        // переделать!!!
        private void FillRoles()
        {
            if (_roleManager.Roles.Count() == 0)
            {
                _roleManager.CreateAsync(new IdentityRole("Admin"));
                _roleManager.CreateAsync(new IdentityRole("Moderator"));
                _roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        public AuthenticateResult TryLogin(User model, string password, bool rememberMe = false)
        {
            var result = _signInManager.PasswordSignInAsync(model.Email, password, rememberMe, false).GetResult();
            
            if (result.Succeeded)
                return new AuthenticateResult();
            else
                return new AuthenticateResult("Некоректний логін або пароль");
        }

        public AuthenticateResult TryRegistration(User model, string password, bool rememberMe = false, string roleName = "Admin")
        {
            User user = new User
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
                IsRemoved = false,
                DateOfRegistration = DateTime.UtcNow,
            };

            // добавляем пользователя
            IdentityResult result = _userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                _userManager.AddToRolesAsync(user, new List<string>() { roleName }).GetResult();

                // установка куки
                _signInManager.SignInAsync(user, rememberMe).GetResult();
                return new AuthenticateResult();
            }
            else
            {
                var errors = result.Errors
                    .Select(o => o.Description)
                    .ToList();
                return new AuthenticateResult(errors);
            }
        }

        public bool IsAuthorized(ClaimsPrincipal user) => _signInManager.IsSignedIn(user);

        public void Logout() => _signInManager.SignOutAsync();
    }
}
