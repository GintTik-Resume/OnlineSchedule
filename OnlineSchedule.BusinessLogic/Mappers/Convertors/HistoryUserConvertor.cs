using AutoMapper;
using OnlineSchedule.BusinessLogic.Services;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;
using OnlineSchedule.Presentation.ViewModels;

namespace OnlineSchedule.BusinessLogic.Mappers.Convertors
{
    public class HistoryUserConvertor : ITypeConverter<HistoryUserItem, HistoryUserViewModel>
    {
        private readonly UserService _userService;
        private readonly ITypeOfActionRepository _typeOfActionRepository;

        public HistoryUserConvertor(UserService userService, ITypeOfActionRepository typeOfActionRepository)
        {
            _userService = userService;
            _typeOfActionRepository = typeOfActionRepository;
        }

        public HistoryUserViewModel Convert(HistoryUserItem source, HistoryUserViewModel destination, ResolutionContext context)
        {
            var user = _userService.GetUser(source.UserId);
            var performer = _userService.GetUser(source.PerformerId);
            var roles = String.Join(", ", _userService.GetUserRole(performer));
            var typeOfAction = _typeOfActionRepository.Get(source.TypeOfActionId);

            return new HistoryUserViewModel()
            {
                UserEmail = user.Email,
                PerformerEmail = performer.Email,
                PerformerRole = roles,
                DateOfAction = source.DateOfAction,
                TypeOfAction = typeOfAction.Name
            };
        }
    }
}
