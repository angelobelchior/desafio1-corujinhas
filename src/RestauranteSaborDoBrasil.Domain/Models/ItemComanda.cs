using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class ItemComanda : Entity
    {
        public Guid ComandaId { get; set; }
        public Guid PratoId { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }

        public virtual Comanda Comanda { get; set; }
        public virtual Prato Prato { get; set; }
        public virtual ICollection<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }
    }
}
