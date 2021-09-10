using RestauranteSaborDoBrasil.Domain.Core.Models;
using RestauranteSaborDoBrasil.Domain.Enums;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Log : Entity
    {
        public TipoLog Tipo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
