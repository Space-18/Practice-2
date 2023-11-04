using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Libro.Commands.DeleteLibro
{
    internal class DeleteLibroCommandHandler : IRequestHandler<DeleteLibroCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteLibroCommandHandler> _logger;

        public DeleteLibroCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteLibroCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeleteLibroCommand request, CancellationToken cancellationToken)
        {
            var libro = await ExistRecordInDatabase(request.Id);

            _unitOfWork.LibroRepository.DeleteAsync(libro);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Libro {request.Id} eliminado.");
        }

        private async Task<Domain.Libro> ExistRecordInDatabase(string id)
        {
            var result = await _unitOfWork.LibroRepository.GetByIdAsync(id);

            if (result == null)
            {
                _logger.LogError($"Libro {id} no eliminado, no se encontró el recurso.");
                throw new NotFoundException(typeof(Domain.Libro).Name, id);
            }
            else
            {
                return result;
            }
        }
    }
}
