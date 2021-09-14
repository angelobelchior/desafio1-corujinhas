using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response
{
    public class PratoResponse : ResponseBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ReceitaResponse> Receita { get; set; }

        public class ReceitaResponse
        {
            public string Ingrediente { get; set; }
            public float Quantidade { get; set; }
        }
    }
}
