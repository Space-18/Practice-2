using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Libro;
using MediatR;

namespace Biblioteca.Application.Features.Libro.Queries.GetLibros
{
    internal class GetLibrosQueryHandler : IRequestHandler<GetLibrosQuery, List<LibrosViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLibrosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LibrosViewModel>> Handle(GetLibrosQuery request, CancellationToken cancellationToken)
        {
            var libroList = await _unitOfWork.LibroRepository.GetAllAsync();
            libroList = libroList.OrderBy(x => x.Nombre).ToList();
            return _mapper.Map<List<LibrosViewModel>>(libroList);
        }
    }
}
