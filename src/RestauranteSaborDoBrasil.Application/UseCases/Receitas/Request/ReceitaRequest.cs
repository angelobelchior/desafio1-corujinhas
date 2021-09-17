using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request
{
    public class ReceitaRequest : CommandRequest<bool>
    {
        public Guid PratoId { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }

        public class Ingrediente
        {
            public Guid IngredienteId { get; set; }
            public float Quantidade { get; set; }
        }
    }
}
