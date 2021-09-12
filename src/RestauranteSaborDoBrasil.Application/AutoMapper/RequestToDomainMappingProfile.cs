using AutoMapper;
using RestauranteSaborDoBrasil.Application.Events.Log;
using RestauranteSaborDoBrasil.Domain.Models;

namespace RestauranteSaborDoBrasil.Application.AutoMapper
{
    public class RequestToDomainMappingProfile : Profile
    {
        public RequestToDomainMappingProfile()
        {
            CreateMap<LogEvent, Log>();
        }
    }
}
