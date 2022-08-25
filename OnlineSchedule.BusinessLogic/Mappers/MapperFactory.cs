using AutoMapper;
using OnlineSchedule.Presentation.ViewModels;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.BusinessLogic.Mappers.Convertors;
using Microsoft.AspNetCore.Http;
using OnlineSchedule.BusinessLogic.Services;

namespace OnlineSchedule.BusinessLogic.Mappers
{
    public class MapperFactory
    {
        private readonly IServiceProvider _provider;

        public MapperFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        private MapperConfiguration _configuration => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<LoginViewModel, User>();
            cfg.CreateMap<RegistrationViewModel, User>();
            cfg.CreateMap<CreateUserViewModel, User>();
            cfg.CreateMap<UserShortDataViewModel, User>()
                .ReverseMap()
                .ConvertUsing(new ShortUserConvertor(GetService<UserService>()));
        });

        public Mapper Create()
        {
            return new Mapper(_configuration);
        }

        private T GetService<T>()
        {
            var service = _provider.GetService(typeof(T));

            if (service == null)
                return default;

            return (T)service;
        }
    }
}
