using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Response;
using RestauranteSaborDoBrasil.Domain.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Application.UseCases.Mesas.Request
{
    public class ListarMesaRequest : CommandRequest<List<MesaResponse>>
    {

    }
}
