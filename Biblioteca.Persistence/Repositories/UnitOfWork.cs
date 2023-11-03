using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Contracts.Persistence.Commons;
using Biblioteca.Domain.Commons;
using Biblioteca.Persistence.Repositories.Commons;
using System.Collections;

namespace Biblioteca.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private ILibroRepository _libroRepository;
        private IAutorRepository _autorRepository;
        private IEditorialRepository _editorialRepository;
        private ICategoriaRepository _categoriaRepository;
        private readonly ApplicationDBContext _context;

        public ILibroRepository LibroRepository => _libroRepository ??= new LibroRepository(_context);
        public IAutorRepository AutorRepository => _autorRepository ??= new AutorRepository(_context);
        public IEditorialRepository EditorialRepository => _editorialRepository ??= new EditorialRepository(_context);
        public ICategoriaRepository CategoriaRepository => _categoriaRepository ??= new CategoriaRepository(_context);

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel
        {
            if (_repositories == null)
            {
                _repositories = new();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var respositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(respositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseRepository<TEntity>)_repositories[type];
        }
    }
}
