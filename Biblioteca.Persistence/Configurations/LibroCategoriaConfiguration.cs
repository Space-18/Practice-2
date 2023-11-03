using Biblioteca.Domain.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Persistence.Configurations
{
    internal class LibroCategoriaConfiguration : IEntityTypeConfiguration<LibroCategoria>
    {
        public void Configure(EntityTypeBuilder<LibroCategoria> builder)
        {
            builder.HasData(
                new LibroCategoria { LibroId = "f24bda29-28c1-40c1-b478-6034a6e40805", CategoriaId = "d00f17b3-2fb9-48bf-943b-d988e0293dbb" },
                new LibroCategoria { LibroId = "d14296fa-6f8c-4b79-8743-8ac42cf8519c", CategoriaId = "104f1d54-7003-498d-93e6-c9d66ffd57cf" });
        }
    }
}
