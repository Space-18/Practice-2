using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Persistence.Repositories.Commons;

namespace Biblioteca.Persistence.Repositories
{
    internal class LibroRepository : BaseRepository<Libro>, ILibroRepository
    {
        public LibroRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
