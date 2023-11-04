using Biblioteca.Application.Models.Response.Libro;
using MediatR;

namespace Biblioteca.Application.Features.Libro.Queries.GetLibroById
{
    public class GetLibroByIdQuery : IRequest<LibroCategoriaAutorEditorialViewModel>
    {
        public string Id { get; set; }
    }
}
