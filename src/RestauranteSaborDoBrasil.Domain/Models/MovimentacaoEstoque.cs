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
        public Guid? ItemNotaId { get; set; }
        public Guid? ItemComandaId { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
        public virtual ItemNotaEntrada ItemNotaEntrada { get; set; }
        public virtual ItemComanda ItemComanda { get; set; }
    }
}