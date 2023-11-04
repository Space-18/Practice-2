using Biblioteca.Application.Models.Response.Autor;
using Biblioteca.Application.Models.Response.Categoria;
using Biblioteca.Application.Models.Response.Editorial;

namespace Biblioteca.Application.Models.Response.Libro
{
    internal record LibroCategoriaAutorEditorialViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public long ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Imagen { get; set; } = string.Empty;
        public virtual List<CategoriaViewModel> Categorias { get; set; }
        public virtual List<AutorViewModel> Autors { get; set; }
        public virtual List<EditorialViewModel> Editorials { get; set; }
    }
}
