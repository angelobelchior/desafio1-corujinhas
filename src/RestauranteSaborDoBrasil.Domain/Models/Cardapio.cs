using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Enums;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Cardapio : Entity
    {
        public DiaSemana DiaSemana { get; set; }
        public ICollection<PratoCardapio> Pratos { get; set; }
    }
}
