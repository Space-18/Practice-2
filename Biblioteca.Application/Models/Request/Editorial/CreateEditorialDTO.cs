namespace Biblioteca.Application.Models.Request.Editorial
{
    public record CreateEditorialDTO
    {
        public string Nombre { get; set; }
        public string SitioWeb { get; set; }
        public List<string> LibroId { get; set; }
    }
}
