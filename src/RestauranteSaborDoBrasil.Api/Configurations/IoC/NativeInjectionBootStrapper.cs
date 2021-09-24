using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSaborDoBrasil.Application.Events.LogApp;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Infra.Data.Repositories.Base;
using RestauranteSaborDoBrasil.Infra.Data.UoW;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Api.Configurations.IoC
{
    public static class NativeInjectionBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            RegisterInfraService(services);
            RegisterDomainServices(services);
            RegisterApplicationServices(services);
            return services;
        }

        public static void RegisterInfraService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IHandler<DomainNotification>, DomainNotificationHandler>();
        }

        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<LogEvent>, RegisterLogEventHandler>();

            services.AddScoped<IRequestHandler<CriarPratoRequest, PratoResponse>, CriarPratoUseCase>();
            services.AddScoped<IRequestHandler<EditarPratoRequest, PratoResponse>, EditarPratoUseCase>();
            services.AddScoped<IRequestHandler<ListarPratoRequest, List<PratoResponse>>, ListarPratosUseCase>();
            services.AddScoped<IRequestHandler<BuscarPratoRequest, PratoResponse>, BuscarPratoPorIdUseCase>();

            services.AddScoped<IRequestHandler<CriarIngredienteRequest, IngredienteResponse>, CriarIngredienteUseCase>();
            services.AddScoped<IRequestHandler<EditarIngredienteRequest, IngredienteResponse>, EditarIngredienteUseCase>();
            services.AddScoped<IRequestHandler<ListarIngredienteRequest, List<IngredienteResponse>>, ListarIngredienteUseCase>();
            services.AddScoped<IRequestHandler<BuscarIngredienteRequest, IngredienteResponse>, BuscarIngredientePorIdUseCase>();

            services.AddScoped<IRequestHandler<CriarCardapioRequest, CardapioResponse>, CriarCardapioUseCase>();
            services.AddScoped<IRequestHandler<EditarCardapioRequest, CardapioResponse>, EditarCardapioUseCase>();
            services.AddScoped<IRequestHandler<ListarCardapioRequest, List<CardapioResponse>>, ListarCardapiosUseCase>();
            services.AddScoped<IRequestHandler<BuscarCardapioRequest, CardapioResponse>, BuscarCardapioPorIdUseCase>();
            services.AddScoped<IRequestHandler<BuscarCardapioDiaRequest, CardapioResponse>, BuscarCardapioPorDiaUseCase>();

            services.AddScoped<IRequestHandler<ListarMesaRequest, List<MesaResponse>>, ListarMesaUseCase>();
            services.AddScoped<IRequestHandler<BuscarMesaPorIdRequest, MesaResponse>, BuscarMesaPorIdUseCase>();

            services.AddScoped<IRequestHandler<EditarReceitaRequest, bool>, EditarReceitaUseCase>();
        }
    }
}
