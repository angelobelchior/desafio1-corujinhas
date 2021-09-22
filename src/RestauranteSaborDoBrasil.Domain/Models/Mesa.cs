using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Enums;
using System.Collections.Generic;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Mesa : Entity
    {
        public string Numero { get ; set; }
        public int QuantidadeMax { get; set; }

        public virtual ICollection<HistoricoMesa> Historico { get; set; }
    }
}
