using MediatR;

namespace Biblioteca.Application.Features.Editorial.Commands.UpdateEditorial
{
    public record UpdateEditorialCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string SitioWeb { get; set; }
        public List<string> LibroId { get; set; }
    }
}
