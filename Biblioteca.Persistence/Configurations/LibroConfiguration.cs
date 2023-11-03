using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Persistence.Configurations
{
    internal class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.HasData(
                new Libro { Id = "f24bda29-28c1-40c1-b478-6034a6e40805", Nombre = "Paco yunque", ISBN = 9786123022723, FechaPublicacion = new DateTime(1951, 01, 01), CreateBy = "System" },
                new Libro { Id = "d14296fa-6f8c-4b79-8743-8ac42cf8519c", Nombre = "El túnel", ISBN = 9786124507724, FechaPublicacion = new DateTime(1948, 01, 01), CreateBy = "System" }
                );
        }
    }
}
