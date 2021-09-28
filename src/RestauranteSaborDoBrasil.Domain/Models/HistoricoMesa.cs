using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class HistoricoMesa : Entity
    {
        public Guid MesaId { get; set; }
        public int QuantidadeOcupantes { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }

        public virtual Mesa Mesa { get; set; }
    }
}
