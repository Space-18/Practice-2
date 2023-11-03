using Biblioteca.Domain.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Persistence.Configurations
{
    internal class LibroEditorialConfiguration : IEntityTypeConfiguration<LibroEditorial>
    {
        public void Configure(EntityTypeBuilder<LibroEditorial> builder)
        {
            builder.HasData(
                new LibroEditorial { LibroId = "f24bda29-28c1-40c1-b478-6034a6e40805", EditorialId = "9e58bacf-7a01-4ac3-a919-3318522b3733" },
                new LibroEditorial { LibroId = "f24bda29-28c1-40c1-b478-6034a6e40805", EditorialId = "bb2fe83f-dc5a-4fe2-b26d-9de8d2bb1308" },
                new LibroEditorial { LibroId = "d14296fa-6f8c-4b79-8743-8ac42cf8519c", EditorialId = "bb2fe83f-dc5a-4fe2-b26d-9de8d2bb1308" });
        }
    }
}
