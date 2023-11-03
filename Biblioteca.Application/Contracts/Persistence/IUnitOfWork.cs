using Biblioteca.Application.Contracts.Persistence.Commons;
using Biblioteca.Domain.Commons;

namespace Biblioteca.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ILibroRepository LibroRepository { get; }
        IAutorRepository AutorRepository { get; }
        IEditorialRepository EditorialRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel;

        Task<int> Complete();
    }
}
