using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Autor;
using MediatR;

namespace Biblioteca.Application.Features.Autor.Queries.GetAutorById
{
    internal class GetAutorByIdQueryHandler : IRequestHandler<GetAutorByIdQuery, AutorLibrosViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAutorByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AutorLibrosViewModel> Handle(GetAutorByIdQuery request, CancellationToken cancellationToken)
        {
            var autor = await _unitOfWork.AutorRepository.GetAutorWithLibros(request.Id);
            return _mapper.Map<AutorLibrosViewModel>(autor);
        }
    }
}
