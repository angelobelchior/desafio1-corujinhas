using RestauranteSaborDoBrasil.Application.Validations.Ingredientes;

namespace RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request
{
    public class CriarIngredienteRequest : IngredienteRequest
    {
        public override bool IsValid()
        {
            ValidationResult = new CriarIngredienteRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
