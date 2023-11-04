using MediatR;

namespace Biblioteca.Application.Features.Categoria.Commands.UpdateCategoria
{
    public record UpdateCategoriaCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}
