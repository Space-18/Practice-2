using MediatR;

namespace Biblioteca.Application.Features.Editorial.Commands.DeleteEditorial
{
    public record DeleteEditorialCommand : IRequest
    {
        public string Id { get; set; }
    }
}
