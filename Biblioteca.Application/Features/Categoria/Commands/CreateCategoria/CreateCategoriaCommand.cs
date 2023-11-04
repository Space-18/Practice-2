using MediatR;

namespace Biblioteca.Application.Features.Categoria.Commands.CreateCategoria
{
    public record CreateCategoriaCommand : IRequest<string>
    {
        public string Nombre { get; set; }
    }
}
