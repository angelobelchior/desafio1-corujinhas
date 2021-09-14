using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace RestauranteSaborDoBrasil.Api.Configurations.Swagger
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            if(services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestauranteSaborDoBrasil.Api", Version = "v1" });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

                OpenApiSecurityScheme secuurityDefinition = new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Inform o token de autorização",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http
                };

                c.AddSecurityDefinition("jwt_token", secuurityDefinition);


            });
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, string name)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", name));

            return app;
        }
    }
}
