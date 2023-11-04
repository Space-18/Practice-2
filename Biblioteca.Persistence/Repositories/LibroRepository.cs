using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using Biblioteca.Domain;
using Biblioteca.Persistence.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence.Repositories
{
    internal class LibroRepository : BaseRepository<Libro>, ILibroRepository
    {
        public LibroRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Libro> GetLibroWithCategoriaWithAutorWithEditorial(string id)
        {
            try
            {
                return await _context.Libros
                    .Include(x => x.Categorias)
                    .Include(x => x.Autors)
                    .Include(x => x.Editorials)
                    .FirstAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener libro Id: {id}.");
            }
        }

        public async Task<string> AddLibroWithCategoriaWithAutorWithEditorial(Libro libro)
        {
            try
            {
                var exist = await GetByAsync(x => x.ISBN == libro.ISBN);

                if (exist != null)
                {
                    throw new BadRequestException("El ISBN del libro ya existe.");
                }

                AddAsync(libro);

                return libro.Id;
            }
            catch (Exception e)
            {
                throw new Exception($"Error al crear el libro: {e.Message}");
            }
        }
    }
}
