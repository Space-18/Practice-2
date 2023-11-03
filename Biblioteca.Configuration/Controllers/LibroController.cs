using AutoMapper;
using Biblioteca.Application.Features.Libro.Queries.GetLibros;
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
    }
}
