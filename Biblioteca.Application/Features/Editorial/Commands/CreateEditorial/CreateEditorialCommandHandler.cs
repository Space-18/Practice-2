using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Editorial.Commands.CreateEditorial
{
    internal class CreateEditorialCommandHandler : IRequestHandler<CreateEditorialCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEditorialCommandHandler> _logger;

        public CreateEditorialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateEditorialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(CreateEditorialCommand request, CancellationToken cancellationToken)
        {
            await ExistRecordInDatabase(request);

            var libroIds = await _unitOfWork.LibroRepository.GetAsync(x => request.LibroId.Contains(x.Id));

            var editorial = _mapper.Map<Domain.Editorial>(request);

            editorial.Libros = libroIds.ToList();

            _unitOfWork.EditorialRepository.AddAsync(editorial);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Editorial `{request.Nombre}` creada.");
            return editorial.Id;
        }

        private async Task ExistRecordInDatabase(CreateEditorialCommand request)
        {
            var result = await _unitOfWork.EditorialRepository.GetByAsync(x => (x.Nombre == request.Nombre && x.SitioWeb == request.SitioWeb));

            if (result != null)
            {
                _logger.LogError($"Editorial `{request.Nombre}` no creado, ya existe uno con los mismos valores.");
                throw new BadRequestException($"El record no se pudo crear: {typeof(Domain.Editorial).Name}");
            }
        }
    }
}
