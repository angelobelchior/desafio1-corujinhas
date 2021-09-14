using FluentValidation;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;

namespace RestauranteSaborDoBrasil.Application.Validations.Pratos
{
    public class PratoRequestValidation<TRequest> : AbstractValidator<TRequest>
        where TRequest : PratoRequest, new()
    {
        public PratoRequestValidation()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Receitas)
                .NotEmpty();
        }
    }
}
