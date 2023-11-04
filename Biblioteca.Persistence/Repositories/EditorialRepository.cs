using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Persistence.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence.Repositories
{
    internal class EditorialRepository : BaseRepository<Editorial>, IEditorialRepository
    {
        public EditorialRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Editorial> GetEditorialWithLibros(string id)
        {
            try
            {
                return await _context.Editorials.Include(x => x.Libros).FirstAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener editorial Id: {id}.");
            }
        }
    }
}
