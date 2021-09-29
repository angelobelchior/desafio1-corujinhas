using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class ItemNotaEntrada : Entity
    {
        public Guid NotaEntradaId { get; set; }
        public Guid IngredienteId { get; set; }
        public float Quantidade { get; set; }

        public virtual NotaEntrada NotaEntrada { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public virtual MovimentacaoEstoque MovimentacaoEstoque { get; set; }
    }
}
