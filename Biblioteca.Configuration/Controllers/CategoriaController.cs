using AutoMapper;
using Biblioteca.Application.Features.Categoria.Commands.CreateCategoria;
using Biblioteca.Application.Features.Categoria.Commands.DeleteCategoria;
using Biblioteca.Application.Features.Categoria.Commands.UpdateCategoria;
using Biblioteca.Application.Features.Categoria.Queries.GetCategoriaById;
using Biblioteca.Application.Features.Categoria.Queries.GetCategorias;
using Biblioteca.Application.Models.Request.Categoria;
using Biblioteca.Configuration.Controllers.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biblioteca.Configuration.Controllers
{
    public class CategoriaController : BaseController
    {
        public CategoriaController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpGet(Name = "GetCategorias")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetCategorias()
        {
            var query = new GetCategoriasQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}", Name = "GetCategoriaById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetCategoriaById(string id)
        {
            var query = new GetCategoriaByIdQuery(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "CreateCategoria")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateCategoria([FromBody]CategoriaDTO categoria)
        {
            var command = _mapper.Map<CreateCategoriaCommand>(categoria);
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }

        [HttpPut("{id}",Name = "UpdateCategoria")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateCategoria(string id, [FromBody]CategoriaDTO categoria)
        {
            var command = new UpdateCategoriaCommand { Id = id, Nombre = categoria.Nombre };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteCategoria")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteCategoria(string id)
        {
            var command = new DeleteCategoriaCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
