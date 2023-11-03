using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain
{
    public class Autor : BaseModel
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Pseudonimo { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        //public string EstadoId { get; set; }

        //public virtual Estado Estado { get; set; }
        public virtual List<Libro> Libros { get; set; } = new();
    }
}
