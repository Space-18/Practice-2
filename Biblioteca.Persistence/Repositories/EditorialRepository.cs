using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Persistence.Repositories.Commons;

namespace Biblioteca.Persistence.Repositories
{
    internal class EditorialRepository : BaseRepository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
