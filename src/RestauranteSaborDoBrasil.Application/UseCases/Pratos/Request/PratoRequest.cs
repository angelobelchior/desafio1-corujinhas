using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request
{
    public class PratoRequest : CommandRequest<PratoResponse>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<ReceitaRequest> Receita { get; set; }

        public class ReceitaRequest
        {
            public Guid IngredienteId { get; set; }
            public float Quantidade { get; set; }
        }
    }
}
