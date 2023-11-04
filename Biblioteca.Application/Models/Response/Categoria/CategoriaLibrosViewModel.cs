using Biblioteca.Application.Models.Response.Libro;

namespace Biblioteca.Application.Models.Response.Categoria
{
    internal record CategoriaLibrosViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public List<LibrosViewModel> Libros { get; set; }
    }
}
