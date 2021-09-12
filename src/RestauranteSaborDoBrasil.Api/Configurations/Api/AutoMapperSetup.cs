using Microsoft.Extensions.DependencyInjection;
using System;
using RestauranteSaborDoBrasil.Application.AutoMapper;

namespace RestauranteSaborDoBrasil.Api.Configurations.Api
{
    public static class AutoMapperSetup
    {
        public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(RequestToDomainMappingProfile));

            AutoMapperConfig.RegisterMappings();

            return services;
        }
    }
}
