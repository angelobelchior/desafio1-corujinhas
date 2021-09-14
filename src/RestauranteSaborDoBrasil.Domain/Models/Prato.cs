using RestauranteSaborDoBrasil.Domain.Core.Models;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Prato : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual IEnumerable<Receita> Receitas { get; set; }
        public virtual IEnumerable<PratoCardapio> Cardapios { get; set; }
    }
}
