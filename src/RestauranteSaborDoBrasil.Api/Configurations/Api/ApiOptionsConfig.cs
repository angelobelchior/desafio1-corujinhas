using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSaborDoBrasil.Domain.Core.Providers;

namespace RestauranteSaborDoBrasil.Api.Configurations.Api
{
    internal static class ApiOptionsConfig
    {
        public static void LoadConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var dbSettings = configuration.Get<DbSettings>();

            services.AddSingleton(typeof(DbSettings), dbSettings);
        }
    }
}