using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain.Relations
{
    public class LibroEditorial : BaseModel
    {
        public string LibroId { get; set; }
        public string EditorialId { get; set; }
    }
}
