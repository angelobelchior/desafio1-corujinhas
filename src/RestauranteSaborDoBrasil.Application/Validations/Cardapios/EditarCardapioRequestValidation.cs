using FluentValidation;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;

namespace RestauranteSaborDoBrasil.Application.Validations.Cardapios
{
    public class EditarCardapioRequestValidation : CardapioRequestValidation<EditarCardapioRequest>
    {
        public EditarCardapioRequestValidation()
        {
            RuleFor(x => x.Id)
                  .NotNull()
                  .NotEmpty()
                  .WithMessage(ApplicationResources.CardapioIdIsNotValid);
        }
    }
}
