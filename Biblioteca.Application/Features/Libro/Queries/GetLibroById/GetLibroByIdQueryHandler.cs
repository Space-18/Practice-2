using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Libro;
using MediatR;

namespace Biblioteca.Application.Features.Libro.Queries.GetLibroById
{
    internal class GetLibroByIdQueryHandler : IRequestHandler<GetLibroByIdQuery, LibroCategoriaAutorEditorialViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLibroByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LibroCategoriaAutorEditorialViewModel> Handle(GetLibroByIdQuery request, CancellationToken cancellationToken)
        {
            var libro = await _unitOfWork.LibroRepository.GetLibroWithCategoriaWithAutorWithEditorial(request.Id);

            return _mapper.Map<LibroCategoriaAutorEditorialViewModel>(libro);
        }
    }
}
