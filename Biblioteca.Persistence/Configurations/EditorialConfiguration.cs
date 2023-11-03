using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Persistence.Configurations
{
    internal class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.HasData(
                new Editorial { Id = "9e58bacf-7a01-4ac3-a919-3318522b3733", Nombre = "Libros Peruanos", SitioWeb = "https://www.lperu.com.pe" },
                new Editorial { Id = "bb2fe83f-dc5a-4fe2-b26d-9de8d2bb1308", Nombre = "Crisol", SitioWeb = "https://www.crisol.com" });
        }
    }
}
