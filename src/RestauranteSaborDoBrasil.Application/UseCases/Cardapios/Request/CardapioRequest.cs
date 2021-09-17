using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using RestauranteSaborDoBrasil.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request
{
    public abstract class CardapioRequest : CommandRequest<CardapioResponse>
    {
        public DiaSemana DiaSemana { get; set; }
        public List<PratoRequest> Pratos { get; set; }

        public class PratoRequest
        {
            public Guid PratoId { get; set; }
            public float Preco { get; set; }
        }
    }
}
