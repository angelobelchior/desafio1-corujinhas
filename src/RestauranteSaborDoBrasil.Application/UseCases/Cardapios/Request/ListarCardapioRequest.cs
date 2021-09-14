using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request
{
    public class ListarCardapioRequest : CommandRequest<List<CardapioResponse>>
    {
    }
}
