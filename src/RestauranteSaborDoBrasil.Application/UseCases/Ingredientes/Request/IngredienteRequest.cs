using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;

namespace RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request
{
    public class IngredienteRequest : CommandRequest<IngredienteResponse>
    {
        public string Descricao { get; set; }
        public float EstoqueMinimo { get; set; }
        public float EstoqueMaximo { get; set; }
    }
}
