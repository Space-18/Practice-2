using Biblioteca.Application.Contracts.Persistence.Commons;
using Biblioteca.Domain;

namespace Biblioteca.Application.Contracts.Persistence
{
    public interface IEditorialRepository : IBaseRepository<Editorial>
    {
        Task<Editorial> GetEditorialWithLibros(string id);
    }
}
