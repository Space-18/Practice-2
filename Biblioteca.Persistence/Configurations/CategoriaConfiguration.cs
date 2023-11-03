using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Persistence.Configurations
{
    internal class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData(
                new Categoria { Id = "d00f17b3-2fb9-48bf-943b-d988e0293dbb", Nombre = "Aventuras" },
                new Categoria { Id = "803cc157-da8d-45d2-b341-b1c272538b1e", Nombre = "Acción" },
                new Categoria { Id = "104f1d54-7003-498d-93e6-c9d66ffd57cf", Nombre = "Romance" });
        }
    }
}
