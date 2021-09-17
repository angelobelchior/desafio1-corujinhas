using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response
{
    public class CardapioResponse : ResponseBase
    {
        public string DiaSemana { get; set; }
        public List<PratoResponse> Pratos { get; set; }

        public class PratoResponse
        {
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public float Preco { get; set; }
        }
    }
}
