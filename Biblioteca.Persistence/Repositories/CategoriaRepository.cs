﻿using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Domain;
using Biblioteca.Persistence.Repositories.Commons;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Persistence.Repositories
{
    internal class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Categoria> GetCategoriaWithLibroById(string id)
        {
            try
            {
                return await _context.Categorias.Include(x => x.Libros).FirstAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener categoría Id: {id}.");
            }
        }
    }
}
