using MediatR;

namespace Biblioteca.Application.Features.Categoria.Commands.DeleteCategoria
{
    public record DeleteCategoriaCommand : IRequest
    {
        public string Id { get; set; }
    }
}
