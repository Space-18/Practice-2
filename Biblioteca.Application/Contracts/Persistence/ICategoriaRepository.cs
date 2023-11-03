using Biblioteca.Application.Contracts.Persistence.Commons;
using Biblioteca.Domain;

namespace Biblioteca.Application.Contracts.Persistence
{
    public interface ICategoriaRepository : IBaseRepository<Categoria>
    {
        Task<Categoria> GetCategoriaWithLibroById(string id);
    }
}
