using RestauranteSaborDoBrasil.Domain.Core.Models;
using System.Collections.Generic;
using System; 

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class NotaEntrada : Entity
    {
        public Guid FornecedorId { get; set; }
        public string Numero { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataEntrada { get; set; }

        public Fornecedor Fornecedor { get; set; }
        public virtual ICollection<ItemNotaEntrada> Itens { get; set; }
    }
}
