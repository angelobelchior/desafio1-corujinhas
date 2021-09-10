using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSaborDoBrasil.Api.Controllers.Base;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;

namespace RestauranteSaborDoBrasil.Api.Controllers
{
    public class MesaController : MainController
    {
        public MesaController(IHandler<DomainNotification> notifications) : base(notifications)
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            return CustomResponse(StatusCodes.Status200OK, null);
        }
    }
}
