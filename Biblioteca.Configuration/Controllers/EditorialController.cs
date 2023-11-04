using AutoMapper;
using Biblioteca.Application.Features.Editorial.Commands.CreateEditorial;
using Biblioteca.Application.Features.Editorial.Commands.DeleteEditorial;
using Biblioteca.Application.Features.Editorial.Commands.UpdateEditorial;
using Biblioteca.Application.Features.Editorial.Queries.GetEditorialById;
using Biblioteca.Application.Features.Editorial.Queries.GetEditorials;
using Biblioteca.Application.Models.Request.Editorial;
using Biblioteca.Configuration.Controllers.Commons;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biblioteca.Configuration.Controllers
{
    public class EditorialController : BaseController
    {
        public EditorialController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpGet(Name = "GetEditorials")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetEditorials()
        {
            var query = new GetEditorialQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}", Name = "GetEditorialById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetEditorialById(string id)
        {
            var query = new GetEditorialByIdQuery { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "CreateEditorial")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateEditorial([FromBody] CreateEditorialDTO editorial)
        {
            var command = _mapper.Map<CreateEditorialCommand>(editorial);
            var result = await _mediator.Send(command);
            return StatusCode(201, result);
        }

        [HttpPut("{id}",Name = "UpdateEditorial")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateEditorial(string id, [FromBody] CreateEditorialDTO editorial)
        {
            var command = _mapper.Map<UpdateEditorialCommand>(editorial);
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}",Name = "DeleteEditorial")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> DeleteEditorial(string id)
        {
            var command = new DeleteEditorialCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
