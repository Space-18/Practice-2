using MediatR;

namespace Biblioteca.Application.Features.Libro.Commands.CreateLibro
{
    public record CreateLibroCommand : IRequest<string>
    {
        public string Nombre { get; set; }
        public long ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        //public string Imagen { get; set; }
        public List<string> CategoriaId { get; set; }
        public List<string> AutorId { get; set; }
        public List<string> EditorialId { get; set; }
    }
}
