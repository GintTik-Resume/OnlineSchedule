using AutoMapper;
using OnlineSchedule.BusinessLogic.Services;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.BusinessLogic.Mappers
{
    public static class MapperExtensions
    {
        public static List<UserShortDataViewModel> MapUsersToUserShortDatas(this Mapper mapper, List<User> users, UserService userService)
        {
            var models = mapper.Map<List<UserShortDataViewModel>>(users);
            
            for (int i = 0; i < users.Count; i++)
                models[i].Role = String.Join(", ", userService.GetUserRole(users[i]));

            return models;
        }
    }
}
