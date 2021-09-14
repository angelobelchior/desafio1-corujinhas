using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class PratoCardapio : Entity
    {
        public Guid PratoId { get; set; }
        public Guid CardapioId { get; set; }
        public float Preco { get; set; }

        public virtual Prato Prato { get; set; }
        public virtual Cardapio Cardapio { get; set; }
    }
}
