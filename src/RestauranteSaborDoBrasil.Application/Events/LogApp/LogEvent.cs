using RestauranteSaborDoBrasil.Domain.Core.Messages;
using RestauranteSaborDoBrasil.Domain.Enums;
using System;

namespace RestauranteSaborDoBrasil.Application.Events.LogApp
{
    public class LogEvent : EventRequest
    {
        public TipoLog Tipo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}
