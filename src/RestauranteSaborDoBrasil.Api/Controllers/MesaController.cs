using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSaborDoBrasil.Api.Controllers.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Api.Controllers
{
    public class MesaController : MainController
    {
        private readonly IMediator _mediator;

        public MesaController(IHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todas as mesas cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<MesaResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<List<MesaResponse>>> GetAsync()
        {
            var result = await _mediator.Send(new ListarMesaRequest());
            return CustomResponse(StatusCodes.Status200OK, result);
        }


        /// <summary>
        /// Busca mesa por ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(MesaResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<MesaResponse>> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new BuscarMesaPorIdRequest {Id = id});
            return CustomResponse(StatusCodes.Status200OK, result);
        }

    }
}
