using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Persistence.Repositories.Commons;

namespace Biblioteca.Persistence.Repositories
{
    internal class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
