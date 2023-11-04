using Biblioteca.Application.Models.Response.Autor;
using MediatR;

namespace Biblioteca.Application.Features.Autor.Queries.GetAutorById
{
    public record GetAutorByIdQuery : IRequest<AutorLibrosViewModel>
    {
        public string Id { get; set; }
    }
}
