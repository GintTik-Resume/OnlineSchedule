using AutoMapper;
using OnlineSchedule.BusinessLogic.Services;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.BusinessLogic.Mappers.Convertors
{
    public class ShortUserConvertor : ITypeConverter<User, UserShortDataViewModel>
    {
        private readonly UserService _userService;

        public ShortUserConvertor(UserService userService)
        {
            _userService = userService;
        }

        public UserShortDataViewModel Convert(User source, UserShortDataViewModel destination, ResolutionContext context)
        {
            return new UserShortDataViewModel()
            {
                Name = source.Name,
                Email = source.Email,
                DateOfRegistration = source.DateOfRegistration,
                Role = String.Join(", ", _userService.GetUserRoles(source))
            };
        }
    }
}
