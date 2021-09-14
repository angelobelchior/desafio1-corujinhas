using RestauranteSaborDoBrasil.Domain.Core.Messages;

namespace RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response
{
    public class IngredienteResponse : ResponseBase
    {
        public string Descricao { get; set; }
        public float EstoqueMinimo { get; set; }
        public float EstoqueMaximo { get; set; }
    }
}
