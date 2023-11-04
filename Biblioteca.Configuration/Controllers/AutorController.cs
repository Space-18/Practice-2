using AutoMapper;
using Biblioteca.Application.Features.Autor.Commands.CreateAutor;
using Biblioteca.Application.Features.Autor.Commands.DeleteAutor;
using Biblioteca.Application.Features.Autor.Commands.UpdateAutor;
using Biblioteca.Application.Features.Autor.Queries.GetAutorById;
using Biblioteca.Application.Features.Autor.Queries.GetAutors;
using Biblioteca.Application.Models.Request.Autor;
using Biblioteca.Configuration.Controllers.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biblioteca.Configuration.Controllers
{
    public class AutorController : BaseController
    {
        public AutorController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpGet(Name = "GetAutors")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAutors()
        {
            var query = new GetAutorQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}", Name = "GetAutorById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAutorById(string id)
        {
            var query = new GetAutorByIdQuery { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "CreateAutor")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateAutor([FromBody] CreateAutorDTO autor)
        {
            var command = _mapper.Map<CreateAutorCommand>(autor);
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }

        [HttpPut("{id}", Name = "UpdateAutor")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateAutor(string id, [FromBody] CreateAutorDTO autor)
        {
            var command = _mapper.Map<UpdateAutorCommand>(autor);
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteAutor")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteAutor(string id)
        {
            var command = new DeleteAutorCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
