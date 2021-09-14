using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;

namespace RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request
{
    public class BuscarIngredienteRequest : CommandRequest<IngredienteResponse>
    {
        public Guid Id { get; set; }
    }
}
