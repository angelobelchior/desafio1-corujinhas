using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler
{
    public class ListarPratosUseCase : PratoUseCase<ListarPratoRequest, ListarPratoResponse>
    {
        public ListarPratosUseCase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IBaseRepository<Prato> baseRepository) : base(notifications, unitOfWork, mapper, baseRepository)
        {
        }

        public override async Task<ListarPratoResponse> Handle(ListarPratoRequest request, CancellationToken cancellationToken)
            => await base.Listar();
    }
}
