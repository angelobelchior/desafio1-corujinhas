using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Cardapio : Entity
    {
        public DiaSemana DiaSemana { get; set; }
        public virtual ICollection<PratoCardapio> Pratos { get; set; }

        public List<PratoCardapio> PratosDisponiveis()
            => Pratos.Where(x => x.Prato.PossuiIngredientes()).ToList();
    }
}
