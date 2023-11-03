using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.DeleteCategoria
{
    internal class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteCategoriaCommandHandler> _logger;

        public DeleteCategoriaCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteCategoriaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await ExistRecordInDatabase(request.Id);

            _unitOfWork.CategoriaRepository.DeleteAsync(categoria);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Categoria {request.Id} eliminada.");
        }

        private async Task<Domain.Categoria> ExistRecordInDatabase(string id)
        {
            var result = await _unitOfWork.CategoriaRepository.GetByIdAsync(id);

            if (result == null)
            {
                _logger.LogError($"Categoria {id} no modificada, no se encuentró el recurso");
                throw new NotFoundException(typeof(Domain.Categoria).Name, id);
            }
            else
            {
                return result;
            }
        }
    }
}
