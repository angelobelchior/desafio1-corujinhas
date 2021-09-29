using RestauranteSaborDoBrasil.Domain.Core.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Comanda : Entity
    {
        public Guid ResponsavelId { get; set; }
        public DateTime DataEmissao { get; set; }

        public ComandaMesa ComandaMesa { get; set; }
        public virtual ICollection<ItemComanda> Itens { get; set; }

        public float ValorTotal
            => Itens.Sum(x => x.Quantidade + x.Valor);
    }
}
