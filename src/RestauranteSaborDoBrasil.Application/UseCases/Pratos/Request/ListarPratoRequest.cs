using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request
{
    public class ListarPratoRequest : CommandRequest<List<PratoResponse>>
    {
    }
}
