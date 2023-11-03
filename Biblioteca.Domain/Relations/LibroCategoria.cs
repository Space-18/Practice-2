using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain.Relations
{
    public class LibroCategoria : BaseModel
    {
        public string LibroId { get; set; }
        public string CategoriaId { get; set; }
    }
}
