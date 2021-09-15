using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Receitas.Response
{
    public class ReceitaResponse : ResponseBase
    {
        public string Prato { get; set; }
        public List<IngredienteResponse> Ingredientes { get; set; }

        public class IngredienteResponse 
        {
            public string Ingrediente { get; set; }
            public float Quantidade { get; set; }
        }

    }
}
