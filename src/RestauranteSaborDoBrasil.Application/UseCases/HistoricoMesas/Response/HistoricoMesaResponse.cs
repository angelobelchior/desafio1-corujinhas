using System;

namespace RestauranteSaborDoBrasil.Application.UseCases.HistoricoMesas.Response
{
    public class HistoricoMesaResponse
    {
        public Guid MesaId { get; set; }
        public int QuantidadeOcupantes { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
    }
}
