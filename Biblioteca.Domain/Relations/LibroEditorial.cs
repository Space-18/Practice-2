using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain.Relations
{
    public class LibroEditorial : BaseModel
    {
        public string LibroId { get; set; } = string.Empty;
        public string EditorialId { get; set; } = string.Empty;

        //public virtual Libro Libro { get; set; }
        //public virtual Editorial Editorial { get; set; }
    }
}
