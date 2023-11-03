using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Categoria;
using MediatR;

namespace Biblioteca.Application.Features.Categoria.Queries.GetCategorias
{
    internal class GetCategoriasQueryHandler : IRequestHandler<GetCategoriasQuery, List<CategoriaViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoriasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoriaViewModel>> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categoriasList = await _unitOfWork.CategoriaRepository.GetAllAsync();
            categoriasList = categoriasList.OrderBy(x => x.Nombre).ToList();
            return _mapper.Map<List<CategoriaViewModel>>(categoriasList);
        }
    }
}
