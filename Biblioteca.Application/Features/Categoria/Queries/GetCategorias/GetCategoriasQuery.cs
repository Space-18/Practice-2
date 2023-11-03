using Biblioteca.Application.Models.Response.Categoria;
using MediatR;

namespace Biblioteca.Application.Features.Categoria.Queries.GetCategorias
{
    public record GetCategoriasQuery : IRequest<List<CategoriaViewModel>>
    {
    }
}
