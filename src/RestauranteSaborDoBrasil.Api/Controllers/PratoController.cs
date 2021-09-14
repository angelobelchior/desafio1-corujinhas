using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSaborDoBrasil.Api.Controllers.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Api.Controllers
{
    public class PratoController : MainController
    {
        private readonly IMediator _mediator;
        public PratoController(IHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca um prato por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(PratoResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<List<PratoResponse>>> GetAsync(Guid id)
            => CustomResponse(StatusCodes.Status200OK, await _mediator.Send(new BuscarPratoRequest { Id = id }));
        

        /// <summary>
        /// Lista todos os pratos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<PratoResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<List<PratoResponse>>> GetAsync()
        {
            var result = await _mediator.Send(new ListarPratoRequest());
            return CustomResponse(StatusCodes.Status200OK, result.Result);
        }


        /// <summary>
        /// Cria um novo prato
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, null, typeof(PratoResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<PratoResponse>> PostAsync(CriarPratoRequest request)
        {
            var response = await _mediator.Send(request);
            return CustomResponse(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Edita um prato existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(PratoResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<PratoResponse>> PutAsync([FromRoute] Guid id, [FromBody]EditarPratoRequest request)
        {
            var resposne = await _mediator.Send(request.AtribuirId(id));
            return CustomResponse(StatusCodes.Status200OK, resposne);
        }
    }
}
