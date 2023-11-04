using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Libro.Commands.UpdateLibro
{
    internal class UpdateLibroCommandHandler : IRequestHandler<UpdateLibroCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateLibroCommandHandler> _logger;

        public UpdateLibroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateLibroCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        //los list corregir insert de nuevos list;
        public async Task<string> Handle(UpdateLibroCommand request, CancellationToken cancellationToken)
        {
            var libro = await ExistRecordInDatabase(request.Id);

            var categoriaIds = await _unitOfWork.CategoriaRepository.GetAsync(x => request.CategoriaId.Contains(x.Id));
            var autorIds = await _unitOfWork.AutorRepository.GetAsync(x => request.AutorId.Contains(x.Id));
            var editorialIds = await _unitOfWork.EditorialRepository.GetAsync(x => request.EditorialId.Contains(x.Id));

            _mapper.Map(request, libro);

            libro.Categorias = categoriaIds.ToList();
            libro.Autors = autorIds.ToList();
            libro.Editorials = editorialIds.ToList();

            _unitOfWork.LibroRepository.UpdateAsync(libro);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Libro {libro.Id} modificado.");
            return libro.Id;
        }

        private async Task<Domain.Libro> ExistRecordInDatabase(string id)
        {
            var result = await _unitOfWork.LibroRepository.GetLibroWithCategoriaWithAutorWithEditorial(id);

            if (result == null)
            {
                _logger.LogError($"Libro {id} no modificado, no se encontró el recurso.");
                throw new NotFoundException(typeof(Domain.Libro).Name, id);
            }
            else
            {
                return result;
            }
        }
    }
}
