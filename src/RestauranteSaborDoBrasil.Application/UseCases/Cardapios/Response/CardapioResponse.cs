using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response
{
    public class CardapioResponse : RequestBase
    {
        public string DiaSemana { get; set; }
        public List<PratoResponse> Pratos { get; set; }
    }
}
