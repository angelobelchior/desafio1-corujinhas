using FluentValidation;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;

namespace RestauranteSaborDoBrasil.Application.Validations.Cardapios
{
    public class CardapioRequestValidation<TRequest> : AbstractValidator<TRequest>
        where TRequest : CardapioRequest, new()
    {
        public CardapioRequestValidation()
        {
            RuleFor(x => x.DiaSemana)
                .IsInEnum();

            RuleFor(x => x.Pratos)
                .NotEmpty();
        }
    }
}
