using Biblioteca.Application.Contracts.Persistence.Commons;
using Biblioteca.Domain;

namespace Biblioteca.Application.Contracts.Persistence
{
    public interface IAutorRepository : IBaseRepository<Autor>
    {
        Task<Autor> GetAutorWithLibros(string id);
    }
}
