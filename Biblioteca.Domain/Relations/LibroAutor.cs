using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain.Relations
{
    public class LibroAutor : BaseModel
    {
        public string LibroId { get; set; }
        public string AutorId { get; set; }
    }
}
