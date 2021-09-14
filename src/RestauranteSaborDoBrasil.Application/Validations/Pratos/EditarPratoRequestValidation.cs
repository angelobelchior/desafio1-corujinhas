using FluentValidation;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;

namespace RestauranteSaborDoBrasil.Application.Validations.Pratos
{
    public class EditarPratoRequestValidation : PratoRequestValidation<EditarPratoRequest>
    {
        public EditarPratoRequestValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
