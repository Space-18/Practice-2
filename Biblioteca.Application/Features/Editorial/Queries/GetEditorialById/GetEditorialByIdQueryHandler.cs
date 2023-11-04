using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Editorial;
using MediatR;

namespace Biblioteca.Application.Features.Editorial.Queries.GetEditorialById
{
    internal class GetEditorialByIdQueryHandler : IRequestHandler<GetEditorialByIdQuery, EditorialLibrosViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEditorialByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EditorialLibrosViewModel> Handle(GetEditorialByIdQuery request, CancellationToken cancellationToken)
        {
            var libro = await _unitOfWork.EditorialRepository.GetEditorialWithLibros(request.Id);

            return _mapper.Map<EditorialLibrosViewModel>(libro);
        }
    }
}
