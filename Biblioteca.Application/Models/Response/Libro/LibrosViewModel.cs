namespace Biblioteca.Application.Models.Response.Libro
{
    internal record LibrosViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Imagen { get; set; }
    }
}
