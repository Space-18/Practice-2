using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Autor;
using MediatR;

namespace Biblioteca.Application.Features.Autor.Queries.GetAutors
{
    internal class GetAutorQueryHandler : IRequestHandler<GetAutorQuery, List<AutorViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAutorQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AutorViewModel>> Handle(GetAutorQuery request, CancellationToken cancellationToken)
        {
            var autorList = await _unitOfWork.AutorRepository.GetAllAsync();
            autorList = autorList.OrderBy(x => x.Nombres).ToList();
            return _mapper.Map<List<AutorViewModel>>(autorList);
        }
    }
}
