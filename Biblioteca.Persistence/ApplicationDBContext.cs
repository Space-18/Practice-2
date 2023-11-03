using Biblioteca.Domain;
using Biblioteca.Domain.Commons;
using Biblioteca.Domain.Relations;
using Biblioteca.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence
{
    internal class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Libros = Set<Libro>();
            Autors = Set<Autor>();
            Editorials = Set<Editorial>();
            Categorias = Set<Categoria>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasMany(x => x.Autors)
                .WithMany(x => x.Libros)
                .UsingEntity<LibroAutor>(
                x => x.HasKey(y => new { y.LibroId, y.AutorId })
                );

            modelBuilder.Entity<Libro>()
                .HasMany(x => x.Editorials)
                .WithMany(x => x.Libros)
                .UsingEntity<LibroEditorial>(
                x => x.HasKey(y => new { y.LibroId, y.EditorialId })
                );

            modelBuilder.Entity<Libro>()
                .HasMany(x => x.Categorias)
                .WithMany(x => x.Libros)
                .UsingEntity<LibroCategoria>(
                x => x.HasKey(y => new { y.LibroId, y.CategoriaId })
                );

            //modelBuilder.Entity<Estado>()
            //    .Property(x => x.Abreviatura)
            //    .HasColumnType("char(1)");

            //modelBuilder.ApplyConfiguration(new EstadoConfiguration());
            modelBuilder.ApplyConfiguration(new AutorConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new EditorialConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            modelBuilder.ApplyConfiguration(new LibroAutorConfiguration());
            modelBuilder.ApplyConfiguration(new LibroCategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new LibroEditorialConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "system";//investigar
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid().ToString();
                        entry.Entity.CreateBy = "system";//investigar
                        entry.Entity.CreateDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        //public DbSet<Estado> Estados { get; set; }
    }
}
