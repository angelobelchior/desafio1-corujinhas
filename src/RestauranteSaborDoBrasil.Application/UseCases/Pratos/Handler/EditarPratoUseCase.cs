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
    public class EditarPratoUseCase : PratoUseCase<EditarPratoRequest, PratoResponse>
    {
        public EditarPratoUseCase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IBaseRepository<Prato> baseRepository) : base(notifications, unitOfWork, mapper, baseRepository)
        {
        }

        public override Task<PratoResponse> Handle(EditarPratoRequest request, CancellationToken cancellationToken)
        {
            return base.Handle(request, cancellationToken);
        }
    }
}
