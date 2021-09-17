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
                .GreaterThan(0)
                .NotNull();

            RuleFor(x => x)
                .Must(x => x.EstoqueMaximo > x.EstoqueMinimo)
                .WithMessage("Estoque Máximo dever ser maior que o estoque mínimo");
        }
    }
}
