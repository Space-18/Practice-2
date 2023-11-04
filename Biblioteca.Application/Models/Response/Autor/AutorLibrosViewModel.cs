using Biblioteca.Application.Models.Response.Libro;

namespace Biblioteca.Application.Models.Response.Autor
{
    internal record AutorLibrosViewModel
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Pseudonimo { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual List<LibrosViewModel> Libros { get; set; }
    }
}
