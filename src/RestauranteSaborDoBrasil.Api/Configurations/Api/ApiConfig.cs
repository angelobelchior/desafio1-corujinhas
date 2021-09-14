using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Configuration;
using RestauranteSaborDoBrasil.Api.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using RestauranteSaborDoBrasil.Infra.Data.Context;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations;
using RestauranteSaborDoBrasil.Api.Configurations.Swagger;

namespace RestauranteSaborDoBrasil.Api.Configurations.Api
{
    internal static class ApiConfig
    {
        public static IServiceCollection ConfigureStartupApi(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.LoadConfiguration(configuration);
            services.AddDbContext<ReadingDbContext>();
            services.AddDbContext<WritingDbContext>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.HttpOnly = HttpOnlyPolicy.Always;
                options.Secure = CookieSecurePolicy.Always;
            });

            services.AddControllers(options => { options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())); }).
                SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddWebApiVersioning();

            services.AddCors(options =>
            {
                options.AddPolicy("All",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            services.AddSwaggerDocumentation(configuration);

            return services;
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation("RestauranteSaborDoBrasil.Api v1");
            }

            app.UpdateDatabase();

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddlewareExtension>();

            app.UseRouting();

            app.UseCors("All");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHsts();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
