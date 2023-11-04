using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Editorial;
using MediatR;

namespace Biblioteca.Application.Features.Editorial.Queries.GetEditorials
{
    internal class GetEditorialQueryHandler : IRequestHandler<GetEditorialQuery, List<EditorialViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEditorialQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EditorialViewModel>> Handle(GetEditorialQuery request, CancellationToken cancellationToken)
        {
            var libroList = await _unitOfWork.EditorialRepository.GetAllAsync();
            return _mapper.Map<List<EditorialViewModel>>(libroList);
        }
    }
}
