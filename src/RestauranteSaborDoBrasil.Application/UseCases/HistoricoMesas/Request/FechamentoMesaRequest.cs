using RestauranteSaborDoBrasil.Application.UseCases.HistoricoMesas.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.HistoricoMesas.Request
{
    public class FechamentoMesaRequest : CommandRequest<FechamentoMesaResponse>
    {
        public Guid MesaId { get; set; }
        public int QuantidadeOcupantes { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
    }
}
