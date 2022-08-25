using AutoMapper;
using OnlineSchedule.Presentation.ViewModels;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.BusinessLogic.Mappers.Convertors;

namespace OnlineSchedule.BusinessLogic.Mappers
{
    public class MapperFactory
    {
        private MapperConfiguration _configuration => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<LoginViewModel, User>();
            cfg.CreateMap<RegistrationViewModel, User>();
            cfg.CreateMap<CreateUserViewModel, User>();
            cfg.CreateMap<UserShortDataViewModel, User>()
                .ReverseMap();
            cfg.CreateMap<HistoryUserViewModel, HistoryUserItem>()
                .ReverseMap()
                .ConvertUsing(typeof(HistoryUserConvertor));
        });

        public Mapper Create()
        {
            return new Mapper(_configuration);
        }
    }
}
