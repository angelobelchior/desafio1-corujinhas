using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler
{
    public class BuscarCardapioPorDiaUseCase : UseCaseValidationBase<BuscarCardapioDiaRequest, Cardapio, CardapioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Cardapio> _baseRepository;

        public BuscarCardapioPorDiaUseCase(
            IHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork,
            IBaseRepository<Cardapio> baseRepository,
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public override async Task<CardapioResponse> Handle(BuscarCardapioDiaRequest request, CancellationToken cancellationToken)
        {
            var diaAtual = (DiaSemana)DateTime.UtcNow.DayOfWeek;
            var cardapio = await _baseRepository.GetAllQuery
                .FirstOrDefaultAsync(c => c.DiaSemana == diaAtual, cancellationToken);

            if (cardapio == null)
                return default;

            cardapio.Pratos = cardapio.PratosDisponiveis();

            return _mapper.Map<CardapioResponse>(cardapio);
        }
    }
}
