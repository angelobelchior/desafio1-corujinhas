using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Enums;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class MovimentacaoEstoque : Entity
    {
        public float Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public Guid ResponsavelId { get; set; }
        public TipoMovimentacaoEstoque TipoMovimentacao { get; set; }
        public Guid IngredienteId { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
    }
}
