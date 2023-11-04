using Biblioteca.Application.Models.Response.Categoria;
using MediatR;

namespace Biblioteca.Application.Features.Categoria.Queries.GetCategoriaById
{
    public record GetCategoriaByIdQuery : IRequest<CategoriaLibrosViewModel>
    {
        public string Id { get; set; }
    }
}
