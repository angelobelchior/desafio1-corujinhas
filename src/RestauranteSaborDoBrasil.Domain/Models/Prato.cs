using RestauranteSaborDoBrasil.Domain.Core.Models;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Prato : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Receita> Receitas { get; set; }
        public ICollection<PratoCardapio> Cardapios { get; set; }
    }
}
