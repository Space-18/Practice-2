namespace Biblioteca.Application.Models.Request.Autor
{
    public record CreateAutorDTO
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Pseudonimo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<string>? LibroId { get; set; }
    }
}
