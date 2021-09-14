using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler
{
    public class ListarCardapiosUseCase : UseCaseValidationBase<ListarCardapioRequest, Cardapio, List<CardapioResponse>>
    {
        public ListarCardapiosUseCase(
            IHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork,
            IBaseRepository<Cardapio> baseRepository,
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
        }

        public override async Task<List<CardapioResponse>> Handle(ListarCardapioRequest request, CancellationToken cancellationToken)
            => await base.Listar();
    }
}
