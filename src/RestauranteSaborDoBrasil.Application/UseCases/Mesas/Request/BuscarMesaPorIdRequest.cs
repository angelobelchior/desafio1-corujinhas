using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;

namespace RestauranteSaborDoBrasil.Application.UseCases.Mesas.Request
{
    public class BuscarMesaPorIdRequest :CommandRequest<MesaResponse>
    {
        public Guid Id { get; set; }
    }
}
