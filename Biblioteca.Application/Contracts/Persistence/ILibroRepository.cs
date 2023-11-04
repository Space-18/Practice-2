using Biblioteca.Application.Contracts.Persistence.Commons;
using Biblioteca.Domain;

namespace Biblioteca.Application.Contracts.Persistence
{
    public interface ILibroRepository : IBaseRepository<Libro>
    {
        Task<Libro> GetLibroWithCategoriaWithAutorWithEditorial(string id);
        Task<string> AddLibroWithCategoriaWithAutorWithEditorial(Libro libro);
    }
}
