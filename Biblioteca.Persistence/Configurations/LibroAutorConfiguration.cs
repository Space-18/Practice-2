using Biblioteca.Domain.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Persistence.Configurations
{
    internal class LibroAutorConfiguration : IEntityTypeConfiguration<LibroAutor>
    {
        public void Configure(EntityTypeBuilder<LibroAutor> builder)
        {
            builder.HasData(
                new LibroAutor { LibroId = "f24bda29-28c1-40c1-b478-6034a6e40805", AutorId = "011e0882-1456-4f47-b67a-9981bd1f58c9" },
                new LibroAutor { LibroId = "d14296fa-6f8c-4b79-8743-8ac42cf8519c", AutorId = "ed7514f9-f174-466c-84d9-139c6e219a27" });
        }
    }
}
