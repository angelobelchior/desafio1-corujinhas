using RestauranteSaborDoBrasil.Application.Validations.Cardapios;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request
{
    public class CriarCardapioRequest : CardapioRequest
    {
        public override bool IsValid()
        {
            ValidationResult = new CriarCardapioRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
