using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Receita : Entity
    {
        public Guid PratoId { get; set; }
        public Guid IngredienteId { get; set; }
        public float Quantidade { get; set; }

        public Prato Prato { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
