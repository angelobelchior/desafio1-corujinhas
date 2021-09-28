using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;

namespace RestauranteSaborDoBrasil.Api.Controllers.Base
{

    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public abstract class MainController : Controller
    {
        protected IHandler<DomainNotification> Notifications { get; }

        protected MainController(IHandler<DomainNotification> notifications)
        {
            Notifications = notifications;
        }

        private bool IsValidOperation() => !Notifications.HasNotifications();
        
        protected ActionResult CustomResponse(int statusCode, object result = null)
        {
            if (!IsValidOperation())
                return ResponseBadRequest();

            return statusCode switch
            {
                StatusCodes.Status200OK => Ok(result),
                StatusCodes.Status201Created => Created("", result),
                StatusCodes.Status204NoContent => NoContent(),
                _ => Problem("Internal Server Error", "Controller", 500),
            };
        }

        private ActionResult ResponseBadRequest()
        {
            return BadRequest(new ValidationProblemDetails(Notifications.GetNotificationsByKey()));
        }
        
    }
}
