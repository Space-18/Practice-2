using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Categoria;
using MediatR;

namespace Biblioteca.Application.Features.Categoria.Queries.GetCategoriaById
{
    internal class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaLibrosViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoriaByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoriaLibrosViewModel> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _unitOfWork.CategoriaRepository.GetCategoriaWithLibroById(request.Id);

            return _mapper.Map<CategoriaLibrosViewModel>(categoria);
        }
    }
}
