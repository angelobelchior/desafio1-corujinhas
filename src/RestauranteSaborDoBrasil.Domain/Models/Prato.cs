using RestauranteSaborDoBrasil.Domain.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Prato : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual IEnumerable<Receita> Receitas { get; set; }
        public virtual IEnumerable<PratoCardapio> Cardapios { get; set; }

        public bool PossuiIngredientes()
            => Receitas.All(x => x.Quantidade >= x.Ingrediente.EstoqueAtual);
    }
}
