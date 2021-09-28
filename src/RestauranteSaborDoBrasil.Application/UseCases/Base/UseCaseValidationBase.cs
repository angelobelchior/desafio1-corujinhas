using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Base
{
    public abstract class UseCaseValidationBase<TRequest, TDomainModel, TResponse> : UseCaseBase<TRequest, TResponse>
        where TRequest : CommandRequest<TResponse>, new()
        where TDomainModel : Entity, new()
    {
        private IBaseRepository<TDomainModel> BaseRepository { get; }
        private IMapper Mapper { get; }

        protected UseCaseValidationBase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork,
            IBaseRepository<TDomainModel> baseRepository,
            IMapper mapper
            ) : base(notifications, unitOfWork)
        {
            Mapper = mapper;
            BaseRepository = baseRepository;
        }

        protected bool RequestValidation(TRequest request)
        {
            if (!request.IsValid())
                NotifyValidationErrors(request.ValidationResult);

            return request.IsValid();
        }

        public async Task<TResponse> RegisterAsync(TRequest request)
        {
            if (!RequestValidation(request))
                return default;

            var registerModel = Mapper.Map<TDomainModel>(request);
            registerModel = await BaseRepository.AddAsync(registerModel);

            if (!await CommitAsync())
            {
                var errorMessage = $"Commit could not be performed for '{JsonSerializer.Serialize(request)}'";
                Notifications.Handle(DomainNotification.Error("UseCaseValidationBase", errorMessage));
            }

            return await BuscarPorId(registerModel.Id);
        }

        protected async Task<TResponse> UpdateAsync(TRequest request, Guid id)
        {
            if (!RequestValidation(request))
                return default;

            var updateModel = await BaseRepository.GetByIdAsync(id);

            if (updateModel == null)
            {
                Notifications.Handle(DomainNotification.Error(nameof(TDomainModel), $"{nameof(TDomainModel)} não encontrado!"));
                return default;
            }

            Mapper.Map(request, updateModel);
            BaseRepository.Update(updateModel);


            if (!await CommitAsync())
            {
                var errorMessage = $"Commit não pôde ser realizado para '{JsonSerializer.Serialize(request)}'";
                Notifications.Handle(DomainNotification.Error("UseCaseValidationBase", errorMessage));
            }

            return await BuscarPorId(id);
        }

        protected async Task<TResponse> UpdateAsync(TDomainModel updateModel)
        {
            if (await BaseRepository.GetByIdAsync(updateModel.Id) == null)
            {
                Notifications.Handle(DomainNotification.Error(nameof(TDomainModel), $"{nameof(TDomainModel)} não encontrado!"));
                return default;
            }

            BaseRepository.Update(updateModel);

            if (!await CommitAsync())
            {
                var errorMessage = $"Commit não pôde ser realizado para '{JsonSerializer.Serialize(updateModel)}'";
                Notifications.Handle(DomainNotification.Error("UseCaseValidationBase", errorMessage));
            }

            return await BuscarPorId(updateModel.Id);
        }

        protected async Task<TResponse> Listar()
        {
            var domainModels = await BaseRepository.GetAllQuery
                .ToListAsync();

            return Mapper.Map<TResponse>(domainModels);
        }

        protected async Task<TResponse> BuscarPorId(Guid id)
        {
            var domainModel = await BaseRepository.GetByIdAsync(id);

            return Mapper.Map<TResponse>(domainModel);
        }
    }
}
