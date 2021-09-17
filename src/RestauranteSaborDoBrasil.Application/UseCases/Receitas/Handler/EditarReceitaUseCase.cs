using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Application.UseCases.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Receitas.Handler
{
    public class EditarReceitaUseCase : UseCaseValidationBase<EditarReceitaRequest, Receita, bool>
    {
        private readonly IBaseRepository<Receita> _repository;
        private bool isCommit = false;

        public EditarReceitaUseCase(
            IHandler<DomainNotification> notifications, 
            IUnitOfWork unitOfWork, 
            IBaseRepository<Receita> baseRepository, 
            IMapper mapper) : base(notifications, unitOfWork, baseRepository, mapper)
        {
            _repository = baseRepository;
        }

        public override async Task<bool> Handle(EditarReceitaRequest request, CancellationToken cancellationToken)
        {
            await RemoverIngredientesAntigos(request);
            await AddNovosIngredientes(request);
            return isCommit != true || await CommitAsync();
        }


        private async Task RemoverIngredientesAntigos(EditarReceitaRequest request)
        {
            var ingredientes = await _repository.GetAllQuery.Where(x => x.PratoId.Equals(request.PratoId)).ToListAsync();
            foreach (var ingrediente in ingredientes)
            {
                if (!request.Ingredientes.Any(x => x.IngredienteId.Equals(ingrediente.IngredienteId) && x.Quantidade.Equals(ingrediente.Quantidade)))
                {
                    _repository.Delete(ingrediente);
                    isCommit = isCommit == false || isCommit;
                }
            }
        }

        private async Task AddNovosIngredientes(EditarReceitaRequest request)
        {
            foreach (var ingrediente in request.Ingredientes)
            {
                var exist = await _repository.GetAllQueryNoTracking
                     .FirstOrDefaultAsync(x => x.PratoId.Equals(request.PratoId) && x.IngredienteId.Equals(ingrediente.IngredienteId));

                if (exist == null)
                {
                    await _repository.AddAsync(new Receita { PratoId = request.PratoId, IngredienteId = ingrediente.IngredienteId, Quantidade = ingrediente.Quantidade });
                    isCommit = isCommit == false || isCommit;
                }
            }
        }
   
    }
}
