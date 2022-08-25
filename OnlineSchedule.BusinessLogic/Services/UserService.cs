using Microsoft.AspNetCore.Identity;
using OnlineSchedule.Data.Entities;
using System.Security.Claims;

namespace OnlineSchedule.BusinessLogic.Services
{
    public class UserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public List<User> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        public User GetUser(string id) 
        {
            return _userManager.FindByIdAsync(id).GetAwaiter().GetResult();
        }

        public User GetUser(ClaimsPrincipal principal)
        {
            return _userManager.GetUserAsync(principal).GetAwaiter().GetResult();
        }

        public List<string> GetUserRole(ClaimsPrincipal principal)
        {
            var user = GetUser(principal);
            return GetUserRole(user);
        }

        public List<string> GetUserRole(User user)
        {
            if (user == null)
                return new List<string>();

            return (List<string>)_userManager.GetRolesAsync(user).GetAwaiter().GetResult();
        }

        public bool ExistsRole(ClaimsPrincipal principal, string rolesName)
        {
            var roles = GetUserRole(principal);

            foreach (var roleName in rolesName.Replace(" ", "").Split(","))
                if (roles.Contains(roleName) == true)
                    return true;

            return false;
        }

        public async Task<IdentityResult> TryCreateUser(User model, string password, string roles)
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
            IdentityResult result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, roles.Replace(" ", "").Split(","));

            return result;
        }
    }
}
