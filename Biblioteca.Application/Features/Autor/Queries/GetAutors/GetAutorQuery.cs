using Biblioteca.Application.Models.Response.Autor;
using MediatR;

namespace Biblioteca.Application.Features.Autor.Queries.GetAutors
{
    public record GetAutorQuery : IRequest<List<AutorViewModel>>
    {
    }
}
