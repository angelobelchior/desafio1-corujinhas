using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Mesas.Handler
{
    public class ListarMesaUseCase : UseCaseValidationBase<ListarMesaRequest, Mesa, List<MesaResponse>>

    {
        public ListarMesaUseCase(
            IHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork,
            IBaseRepository<Mesa> baseRepository,
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
        }

        public async override Task<List<MesaResponse>> Handle(ListarMesaRequest request, CancellationToken cancellationToken)
            => await base.Listar();

    }

}
