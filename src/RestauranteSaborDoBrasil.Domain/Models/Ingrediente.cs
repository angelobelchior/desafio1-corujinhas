using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Ingrediente : Entity
    {
        public string Descricao { get; set; }
        public float EstoqueMinimo { get; set; }
        public float EstoqueMaximo { get; set; }

        public virtual ICollection<MovimentacaoEstoque> Movimentacoes { get; set; }
        public virtual ICollection<Receita> Receitas { get; set; }
        public virtual ICollection<ItemNotaEntrada> ItemNotas { get; set; }

        public float EstoqueAtual 
            => Movimentacoes.Where(x => x.TipoMovimentacao.Equals(TipoMovimentacaoEstoque.Entrada)).Sum(x => x.Quantidade) 
            - Movimentacoes.Where(x => x.TipoMovimentacao.Equals(TipoMovimentacaoEstoque.Saida)).Sum(x => x.Quantidade);
    }
}
