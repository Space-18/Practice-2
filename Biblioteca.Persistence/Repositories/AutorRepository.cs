using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Persistence.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence.Repositories
{
    internal class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Autor> GetAutorWithLibros(string id)
        {
            try
            {
                return await _context.Autors
                    .Include(x => x.Libros)
                    .FirstAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener autor Id: {id}.");
            }
        }
    }
}
