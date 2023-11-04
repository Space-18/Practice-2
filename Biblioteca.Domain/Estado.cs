using Biblioteca.Domain.Commons;

namespace Biblioteca.Domain
{
    public class Estado : BaseModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Abreviatura { get; set; } = string.Empty;
    }
}
