using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSaborDoBrasil.Api.Controllers.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Api.Controllers
{
    public class CardapioController : MainController
    {
        private readonly IMediator _mediator;
        public CardapioController(IHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca um cardápio por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(CardapioResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<CardapioResponse>> GetAsync(Guid id)
            => CustomResponse(StatusCodes.Status200OK, await _mediator.Send(new BuscarCardapioRequest { Id = id }));

        /// <summary>
        /// Lista o cardápio do dia
        /// </summary>
        /// <returns></returns>
        [HttpGet("dia")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(CardapioResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<CardapioResponse>> GetDiaAsync()
        {
            var result = await _mediator.Send(new BuscarCardapioDiaRequest());
            return CustomResponse(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Lista todos os cardápios cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<CardapioResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<List<CardapioResponse>>> GetAsync()
        {
            var result = await _mediator.Send(new ListarCardapioRequest());
            return CustomResponse(StatusCodes.Status200OK, result);
        }


        /// <summary>
        /// Cria um novo cardapio
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, null, typeof(CardapioResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<PratoResponse>> PostAsync(CriarCardapioRequest request)
        {
            var response = await _mediator.Send(request);
            return CustomResponse(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Edita um cardápio existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(CardapioResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<PratoResponse>> PutAsync([FromRoute] Guid id, [FromBody] EditarCardapioRequest request)
        {
            var resposne = await _mediator.Send(request.AtribuirId(id));
            return CustomResponse(StatusCodes.Status200OK, resposne);
        }
    }
}
