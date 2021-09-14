using RestauranteSaborDoBrasil.Application.Validations.Ingredientes;
using System;
using System.Text.Json.Serialization;

namespace RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request
{
    public class EditarIngredienteRequest : IngredienteRequest
    {
        [JsonIgnore]
        public Guid Id { get; private set; }

        public EditarIngredienteRequest AtribuirId(Guid id)
        {
            Id = id;
            return this;
        }

        public override bool IsValid()
        {
            ValidationResult = new EditarIngredienteRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
