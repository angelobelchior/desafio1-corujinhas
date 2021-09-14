using MediatR;
using RestauranteSaborDoBrasil.Application.Validations.Cardapios;
using System;
using System.Text.Json.Serialization;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request
{
    public class EditarCardapioRequest : CardapioRequest
    {
        [JsonIgnore]
        public Guid Id { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new EditarCardapioRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public CardapioRequest AtribuirId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
