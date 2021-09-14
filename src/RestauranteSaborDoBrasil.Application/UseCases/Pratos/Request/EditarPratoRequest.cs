using System;
using System.Text.Json.Serialization;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request
{
    public class EditarPratoRequest : PratoRequest
    {
        [JsonIgnore]
        public Guid Id { get; private set; }

        public EditarPratoRequest AtribuirId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
