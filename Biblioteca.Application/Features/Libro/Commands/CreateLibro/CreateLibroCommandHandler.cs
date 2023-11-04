using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Libro.Commands.CreateLibro
{
    internal class CreateLibroCommandHandler : IRequestHandler<CreateLibroCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLibroCommandHandler> _logger;

        public CreateLibroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateLibroCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(CreateLibroCommand request, CancellationToken cancellationToken)
        {
            await ExistRecordInDatabase(request.ISBN);

            var categoriaIds = await _unitOfWork.CategoriaRepository.GetAsync(x => request.CategoriaId.Contains(x.Id));
            var autorIds = await _unitOfWork.AutorRepository.GetAsync(x => request.AutorId.Contains(x.Id));
            var editorialIds = await _unitOfWork.EditorialRepository.GetAsync(x => request.EditorialId.Contains(x.Id));

            var libro = _mapper.Map<Domain.Libro>(request);

            libro.Categorias = categoriaIds.ToList();
            libro.Autors = autorIds.ToList();
            libro.Editorials = editorialIds.ToList();

            _unitOfWork.LibroRepository.AddAsync(libro);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Libro `{request.Nombre}` creado.");
            return libro.Id;
        }

        private async Task ExistRecordInDatabase(long isbn)
        {
            var result = await _unitOfWork.LibroRepository.GetByAsync(x => x.ISBN == isbn);

            if (result != null)
            {
                _logger.LogError($"Libro `{isbn}` no creado, ya existe uno con el mismo ISBN.");
                throw new BadRequestException($"El record no se pudo crear: {typeof(Domain.Libro).Name}");
            }
        }
    }
}
