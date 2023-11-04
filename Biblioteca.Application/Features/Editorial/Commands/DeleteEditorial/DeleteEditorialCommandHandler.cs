using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Editorial.Commands.DeleteEditorial
{
    internal class DeleteEditorialCommandHandler : IRequestHandler<DeleteEditorialCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteEditorialCommandHandler> _logger;

        public DeleteEditorialCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteEditorialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeleteEditorialCommand request, CancellationToken cancellationToken)
        {
            var editorial = await ExistRecordInDatabase(request.Id);

            _unitOfWork.EditorialRepository.DeleteAsync(editorial);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Editorial {request.Id} eliminada.");
        }

        private async Task<Domain.Editorial> ExistRecordInDatabase(string id)
        {
            var result = await _unitOfWork.EditorialRepository.GetByIdAsync(id);

            if (result == null)
            {
                _logger.LogError($"Editorial {id} no eliminada, no se encontró el recurso.");
                throw new NotFoundException(typeof(Domain.Editorial).Name, id);
            }
            else
            {
                return result;
            }
        }
    }
}
