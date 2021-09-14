using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class Receita : Entity
    {
        public Guid PratoId { get; set; }
        public Guid IngredienteId { get; set; }
        public float Quantidade { get; set; }

        public virtual Prato Prato { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
    }
}
