using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain
{
    public class Categoria : BaseModel
    {
        public string Nombre { get; set; } = string.Empty;
        //public string EstadoId { get; set; }

        //public virtual Estado Estado { get; set; }
        public virtual List<Libro> Libros { get; set; } = new();
    }
}
