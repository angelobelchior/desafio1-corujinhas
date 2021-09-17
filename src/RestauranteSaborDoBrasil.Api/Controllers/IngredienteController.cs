using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteSaborDoBrasil.Api.Controllers.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Api.Controllers
{
    public class IngredienteController : MainController
    {
        private readonly IMediator _mediator;
        public IngredienteController(IHandler<DomainNotification> notifications, IMediator mediator) : base(notifications)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Busca um ingrediente por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(IngredienteResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<List<PratoResponse>>> GetAsync(Guid id)
            => CustomResponse(StatusCodes.Status200OK, await _mediator.Send(new BuscarIngredienteRequest { Id = id }));


        /// <summary>
        /// Lista todos os ingredientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(List<IngredienteResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<List<IngredienteResponse>>> GetAsync()
        {
            var result = await _mediator.Send(new ListarIngredienteRequest());
            return CustomResponse(StatusCodes.Status200OK, result);
        }


        /// <summary>
        /// Cria um novo ingrediente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, null, typeof(IngredienteResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<IngredienteResponse>> PostAsync(CriarIngredienteRequest request)
        {
            var response = await _mediator.Send(request);
            return CustomResponse(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Edita um ingrediente existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, null, typeof(IngredienteResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, null, typeof(ValidationProblemDetails))]
        public async Task<ActionResult<IngredienteResponse>> PutAsync([FromRoute] Guid id, [FromBody] EditarIngredienteRequest request)
        {
            var resposne = await _mediator.Send(request.AtribuirId(id));
            return CustomResponse(StatusCodes.Status200OK, resposne);
        }
    }
}
