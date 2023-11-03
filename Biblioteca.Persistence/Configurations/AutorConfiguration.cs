using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Persistence.Configurations
{
    internal class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasData(
                new Autor { Id = "011e0882-1456-4f47-b67a-9981bd1f58c9", Nombres = "César", Apellidos = "Vallejo", CreateBy = "System", Pseudonimo = "" },
                new Autor { Id = "ed7514f9-f174-466c-84d9-139c6e219a27", Nombres = "Ernesto", Apellidos = "Sábato", CreateBy = "System", Pseudonimo = "" },
                new Autor { Id = "16f1fdeb-b4ae-48f2-a4bb-c72ef59c9dbf", Nombres = "Mario", Apellidos = "Varga Llosa", CreateBy = "System", Pseudonimo = "" });
        }
    }
}
