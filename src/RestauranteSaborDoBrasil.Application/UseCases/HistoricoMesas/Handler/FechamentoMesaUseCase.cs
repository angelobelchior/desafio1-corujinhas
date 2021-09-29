using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.HistoricoMesas.Request;
using RestauranteSaborDoBrasil.Application.UseCases.HistoricoMesas.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestauranteSaborDoBrasil.Application.UseCases.HistoricoMesas.Handler
{
    public class FechamentoMesaUseCase : UseCaseValidationBase<FechamentoMesaRequest, HistoricoMesa, FechamentoMesaResponse>
    {
        private readonly IBaseRepository<HistoricoMesa> _fechamentoMesaRepository;
        public FechamentoMesaUseCase(

            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IBaseRepository<HistoricoMesa> baseRepository, 
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
            _fechamentoMesaRepository = baseRepository;
        }

        public override async Task<FechamentoMesaResponse> Handle(FechamentoMesaRequest request, CancellationToken cancellationToken)
        {
            var FechamentoHistorico = await _fechamentoMesaRepository.Where(x => x.MesaId == request.MesaId).OrderByDescending(x => x.DataFechamento).FirstOrDefaultAsync();

            if (FechamentoHistorico != null && FechamentoHistorico.DataFechamento == null)
            {
                Notifications.Handle(DomainNotification
                .Error("Fechamento Mesa", "Informe a data de fechamento da mesa."));
                return default;
            }
            return await base.RegisterAsync(request);
        }
    }
}
