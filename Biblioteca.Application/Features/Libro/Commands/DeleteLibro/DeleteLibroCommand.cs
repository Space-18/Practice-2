using MediatR;

namespace Biblioteca.Application.Features.Libro.Commands.DeleteLibro
{
    public record DeleteLibroCommand : IRequest
    {
        public string Id { get; set; }
    }
}
