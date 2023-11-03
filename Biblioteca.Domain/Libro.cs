using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain
{
    public class Libro : BaseModel
    {
        public string Nombre { get; set; } = string.Empty;
        public long ISBN { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Imagen { get; set; } = string.Empty;
        //public string EstadoId { get; set; }

        //public virtual Estado Estado { get; set; }
        public virtual List<Categoria> Categorias { get; set; } = new();
        public virtual List<Autor> Autors { get; set; } = new();
        public virtual List<Editorial> Editorials { get; set; } = new();
    }
}
