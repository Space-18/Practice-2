using Biblioteca.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Persistence.Configurations
{
    internal class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasData(
                new Estado { Id = "fdd655b4-a091-4a86-baf3-034ee21de4ed", Nombre = "Visible", Abreviatura = "V" },
                new Estado { Id = "3baa8210-fab1-40c7-b391-c63357d65b59", Nombre = "Oculto", Abreviatura = "O" }
                );
        }
    }
}
