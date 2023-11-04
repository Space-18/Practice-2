using Biblioteca.Application.Models.Response.Libro;
using MediatR;

namespace Biblioteca.Application.Features.Libro.Queries.GetLibros
{
    public class GetLibrosQuery : IRequest<List<LibrosViewModel>>
    {
    }
}
