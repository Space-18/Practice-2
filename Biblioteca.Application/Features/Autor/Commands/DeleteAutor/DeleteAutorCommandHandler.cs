using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Autor.Commands.DeleteAutor
{
    internal class DeleteAutorCommandHandler : IRequestHandler<DeleteAutorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteAutorCommandHandler> _logger;

        public DeleteAutorCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteAutorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeleteAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await ExistRecordInDatabase(request.Id);

            _unitOfWork.AutorRepository.DeleteAsync(autor);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Autor {request.Id} eliminado.");
        }

        private async Task<Domain.Autor> ExistRecordInDatabase(string id)
        {
            var autor = await _unitOfWork.AutorRepository.GetByIdAsync(id);

            if (autor == null)
            {
                _logger.LogError($"Autor {id} no eliminado, no se encontró el recurso.");
                throw new NotFoundException(typeof(Domain.Autor).Name, id);
            }
            else
            {
                return autor;
            }
        }
    }
}
