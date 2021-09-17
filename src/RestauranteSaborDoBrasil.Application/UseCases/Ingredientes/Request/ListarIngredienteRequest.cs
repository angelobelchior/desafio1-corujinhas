using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request
{
    public class ListarIngredienteRequest : CommandRequest<List<IngredienteResponse>>
    {
    }
}
