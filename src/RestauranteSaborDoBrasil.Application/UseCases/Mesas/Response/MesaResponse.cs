using RestauranteSaborDoBrasil.Domain.Core.Messages;

namespace RestauranteSaborDoBrasil.Application.UseCases.Mesas.Response
{
    public class MesaResponse :ResponseBase
    {
        public string Numero { get; set; }
        public int QuantidadeMax { get; set; }
    }
}
