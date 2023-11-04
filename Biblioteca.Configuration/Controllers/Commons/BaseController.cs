using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Configuration.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        public BaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
