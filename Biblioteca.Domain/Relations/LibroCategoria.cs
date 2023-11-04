using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain.Relations
{
    public class LibroCategoria : BaseModel
    {
        public string LibroId { get; set; } = string.Empty;
        public string CategoriaId { get; set; } = string.Empty;

        //public virtual Libro Libro { get; set; }
        //public virtual Categoria Categoria { get; set; }
    }
}
