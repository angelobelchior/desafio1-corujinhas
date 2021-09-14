using FluentValidation;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request;

namespace RestauranteSaborDoBrasil.Application.Validations.Ingredientes
{
    public class EditarIngredienteRequestValidation : IngredienteRequestValidation<EditarIngredienteRequest>
    {
        public EditarIngredienteRequestValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
