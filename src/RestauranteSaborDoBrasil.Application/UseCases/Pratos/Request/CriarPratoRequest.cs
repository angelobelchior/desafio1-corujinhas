using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;

namespace RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request
{
    public class CriarPratoRequest : PratoRequest
    {
    }

    public class BuscarPratoRequest : CommandRequest<PratoResponse>
    {
        public Guid Id { get; set; }
    }
}
