using FluentValidation;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request;

namespace RestauranteSaborDoBrasil.Application.Validations.Ingredientes
{
    public class IngredienteRequestValidation<TRequest> : AbstractValidator<TRequest>
    where TRequest : IngredienteRequest, new()
    {
        public IngredienteRequestValidation()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.EstoqueMinimo)
                .NotNull();

            RuleFor(x => x.EstoqueMaximo)
                .NotNull();
        }
    }
}
