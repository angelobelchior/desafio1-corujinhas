using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler
{
    public class EditarCardapioUseCase : UseCaseValidationBase<EditarCardapioRequest, Cardapio, CardapioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<PratoCardapio> _repository;

        public EditarCardapioUseCase(
            IHandler<DomainNotification> notifications,
            IUnitOfWork unitOfWork,
            IBaseRepository<Cardapio> baseRepository,
            IBaseRepository<PratoCardapio> repository,
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task<CardapioResponse> Handle(EditarCardapioRequest request, CancellationToken cancellationToken)
        {
            if (!RequestValidation(request))
                return default;

            await RemoverPratosAntigo(request);
            await AddNovosPratos(request);

            return await base.UpdateAsync(_mapper.Map<Cardapio>(request));
        }

        private async Task RemoverPratosAntigo(EditarCardapioRequest request)
        {
            var pratos = await _repository.GetAllQuery.Where(x => x.CardapioId.Equals(request.Id)).ToListAsync();

            foreach (var prato in pratos)
            {
                if (!request.Pratos.Any(x => x.PratoId.Equals(prato.PratoId) && x.Preco.Equals(prato.Preco)))
                    _repository.Delete(prato);
                
            }
        }

        private async Task AddNovosPratos(EditarCardapioRequest request)
        {
            foreach (var prato in request.Pratos)
            {
                var exist = await _repository.GetAllQueryNoTracking
                     .FirstOrDefaultAsync(x => x.CardapioId.Equals(request.Id) && x.PratoId.Equals(prato.PratoId));

                if (exist == null)
                    await _repository.AddAsync(new PratoCardapio { CardapioId = request.Id, PratoId = prato.PratoId, Preco = prato.Preco });
                
            }
        }
    }
}
