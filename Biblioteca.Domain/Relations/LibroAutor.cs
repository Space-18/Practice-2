using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain.Relations
{
    public class LibroAutor : BaseModel
    {
        public string LibroId { get; set; } = string.Empty;
        public string AutorId { get; set; } = string.Empty;

        //public virtual Libro Libro { get; set; }
        //public virtual Autor Autor { get; set; }
    }
}
