using AutoMapper;
using Biblioteca.Application.Features.Libro.Commands.CreateLibro;
using Biblioteca.Application.Features.Libro.Commands.DeleteLibro;
using Biblioteca.Application.Features.Libro.Commands.UpdateLibro;
using Biblioteca.Application.Features.Libro.Queries.GetLibroById;
using Biblioteca.Application.Features.Libro.Queries.GetLibros;
using Biblioteca.Application.Models.Request.Libro;
using Biblioteca.Configuration.Controllers.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biblioteca.Configuration.Controllers
{
    public class LibroController : BaseController
    {
        public LibroController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {

        }

        [HttpGet(Name = "GetLibros")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetLibros()
        {
            var query = new GetLibrosQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}", Name = "GetLibroById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetLibroById(string id)
        {
            var query = new GetLibroByIdQuery { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "CreateLibro")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateLibro([FromBody] CreateLibroDTO libro)
        {
            var command = _mapper.Map<CreateLibroCommand>(libro);
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }

        [HttpPut("{id}", Name = "UpdateLibro")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateLibro(string id, [FromBody] CreateLibroDTO libro)
        {
            var command = _mapper.Map<UpdateLibroCommand>(libro);
            command.Id = id;

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteLibro")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteLibro(string id)
        {
            var command = new DeleteLibroCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
