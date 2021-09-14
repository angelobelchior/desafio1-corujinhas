using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request
{
    public class BuscarCardapioRequest : CommandRequest<CardapioResponse>
    {
        public Guid Id { get; set; }
    }
}
