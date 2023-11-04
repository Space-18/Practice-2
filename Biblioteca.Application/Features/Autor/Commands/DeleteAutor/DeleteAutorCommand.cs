using MediatR;

namespace Biblioteca.Application.Features.Autor.Commands.DeleteAutor
{
    public record DeleteAutorCommand : IRequest
    {
        public string Id { get; set; }
    }
}
