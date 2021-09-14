using RestauranteSaborDoBrasil.Application.Validations.Pratos;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request
{
    public class CriarPratoRequest : PratoRequest
    {
        public override bool IsValid()
        {
            ValidationResult = new CriarPratoRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
