using Biblioteca.Application.Models.Response.Libro;

namespace Biblioteca.Application.Models.Response.Editorial
{
    internal record EditorialLibrosViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string SitioWeb { get; set; }
        public string Imagen { get; set; }
        public virtual List<LibrosViewModel> Libros { get; set; }
    }
}
