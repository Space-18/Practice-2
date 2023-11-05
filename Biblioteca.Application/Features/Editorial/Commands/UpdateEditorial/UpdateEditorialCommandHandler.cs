using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Editorial.Commands.UpdateEditorial
{
    internal class UpdateEditorialCommandHandler : IRequestHandler<UpdateEditorialCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateEditorialCommandHandler> _logger;

        public UpdateEditorialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateEditorialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateEditorialCommand request, CancellationToken cancellationToken)
        {
            var editorial = await ExistRecordInDatabase(request.Id);

            var libroIds = await _unitOfWork.LibroRepository.GetAsync(x => request.LibroId.Contains(x.Id));

            _mapper.Map(request, editorial);

            editorial.Libros = libroIds.ToList();

            _unitOfWork.EditorialRepository.UpdateAsync(editorial);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Editorial {editorial.Id} modificada.");
            return editorial.Id;
        }

        private async Task<Domain.Editorial> ExistRecordInDatabase(string id)
        {
            var result = await _unitOfWork.EditorialRepository.GetEditorialWithLibros(id);

            if (result == null)
            {
                _logger.LogError($"Editorial {id} no modificada, no se encontró el recurso.");
                throw new NotFoundException(typeof(Domain.Editorial).Name, id);
            }
            else
            {
                return result;
            }
        }
    }
}
