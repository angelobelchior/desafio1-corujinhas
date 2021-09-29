using RestauranteSaborDoBrasil.Domain.Core.Models;
using System;

namespace RestauranteSaborDoBrasil.Domain.Models
{
    public class ComandaMesa : Entity
    {
        public Guid MesaId { get; set; }
        public Guid ComandaId { get; set; }

        public Mesa Mesa { get; set; }
        public Comanda Comanda { get; set; }
    }
}
