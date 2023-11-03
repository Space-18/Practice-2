using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Models.Response.Libro;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var libros = await _unitOfWork.LibroRepository.GetAllAsync();

            return _mapper.Map<List<LibrosViewModel>>(libros);
        }
    }
}
