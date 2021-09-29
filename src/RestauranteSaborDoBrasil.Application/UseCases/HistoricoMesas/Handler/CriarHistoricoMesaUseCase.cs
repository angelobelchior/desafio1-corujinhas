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
    public class CriarHistoricoMesaUseCase : UseCaseValidationBase<CriarHistoricoMesaRequest, HistoricoMesa, HistoricoMesaResponse>
    {
        private readonly IBaseRepository<HistoricoMesa> _historicoMesaRepository;
        public CriarHistoricoMesaUseCase(

            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IBaseRepository<HistoricoMesa> baseRepository, 
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
            _historicoMesaRepository = baseRepository;
        }

        public override async Task<HistoricoMesaResponse> Handle(CriarHistoricoMesaRequest request, CancellationToken cancellationToken)
        {
            var UltimoHistorico = await _historicoMesaRepository.GetAllQuery.Where(x => x.MesaId == request.MesaId)
            .OrderByDescending(x => x.DataAbertura).FirstOrDefaultAsync();

            if (UltimoHistorico != null && UltimoHistorico.DataFechamento == null)
            {
                Notifications.Handle(DomainNotification
                .Error("HistoricoMesa", "Efetue o fechamento da mesa antes de fazer uma nova abertura"));
                return default;
            }
            return await base.RegisterAsync(request);
        }
    }
}