using MediatR;

namespace Biblioteca.Application.Features.Libro.Commands.UpdateLibro
{
    public record UpdateLibroCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public long ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public List<string> CategoriaId { get; set; }
        public List<string> AutorId { get; set; }
        public List<string> EditorialId { get; set; }
    }
}
