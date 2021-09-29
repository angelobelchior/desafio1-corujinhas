using AutoMapper;
using MediatR;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler
{
    public class EditarPratoUseCase : UseCaseValidationBase<EditarPratoRequest, Prato, PratoResponse>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EditarPratoUseCase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IBaseRepository<Prato> baseRepository, 
            IMapper mapper,
            IMediator mediator) : base(notifications, unitOfWork, baseRepository, mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task<PratoResponse> Handle(EditarPratoRequest request, CancellationToken cancellationToken)
        {
            if (!RequestValidation(request))
                return default;

            var receitaRequest = _mapper.Map<EditarReceitaRequest>(request);
            var result = await _mediator.Send(receitaRequest, cancellationToken);

            if (!result)
            {
                Notifications.Handle(DomainNotification.Error("Receita", "Não foi possível salvar a receita deste prato"));
                return default;
            }

            return await base.UpdateAsync(_mapper.Map<Prato>(request));
        }
    }
}
