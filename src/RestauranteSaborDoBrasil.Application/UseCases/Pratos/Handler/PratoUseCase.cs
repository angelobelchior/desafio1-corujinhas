using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler
{
    public abstract class PratoUseCase<TRequest, TResponse> : UseCaseBase<TRequest, TResponse>
        where TRequest : CommandRequest<TResponse>, new()
        where TResponse : ResponseBase, new()
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Prato> _baseRepository;
        
        protected PratoUseCase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IBaseRepository<Prato> baseRepository) : base(notifications, unitOfWork)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
        }

        protected async Task<TResponse> RegistrarPrato(TRequest request)
        {
            var entity = _mapper.Map<Prato>(request);
            await _baseRepository.AddAsync(entity);

            return _mapper.Map<TResponse>(entity);
        }

        protected async Task<TResponse> Listar()
        {
            var entities = await _baseRepository.GetAllQueryNoTracking
                .ToListAsync();

            return _mapper.Map<TResponse>(entities);
        }

        protected async Task<TResponse> BuscarPorId(Guid id)
        {
            var entity = await _baseRepository.GetByIdAsync(id);

            return _mapper.Map<TResponse>(entity);
        }
    }
}
