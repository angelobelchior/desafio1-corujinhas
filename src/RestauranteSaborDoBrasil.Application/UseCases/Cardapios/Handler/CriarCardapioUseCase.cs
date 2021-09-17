using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler
{
    public class CriarCardapioUseCase : UseCaseValidationBase<CriarCardapioRequest, Cardapio, CardapioResponse>
    {
        public CriarCardapioUseCase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IBaseRepository<Cardapio> baseRepository, 
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
        }

        public override async Task<CardapioResponse> Handle(CriarCardapioRequest request, CancellationToken cancellationToken)
           => await base.RegisterAsync(request);

    }
}
