using MediatR;

namespace Biblioteca.Application.Features.Editorial.Commands.CreateEditorial
{
    public record CreateEditorialCommand : IRequest<string>
    {
        public string Nombre { get; set; }
        public string SitioWeb { get; set; }
        public List<string> LibroId { get; set; }
    }
}
