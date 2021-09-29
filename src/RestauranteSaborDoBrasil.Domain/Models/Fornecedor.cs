using RestauranteSaborDoBrasil.Domain.Core.Models;
using System.Collections.Generic;
using System.Collections;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Fornecedor : Entity
    {
        public string RazaoSocial { get; set; }
        public string NomeFantassia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }

        public virtual ICollection<NotaEntrada> Notas { get; set; }
    }
}
