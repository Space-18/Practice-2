using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Autor.Commands.CreateAutor
{
    internal class CreateAutorCommandHandler : IRequestHandler<CreateAutorCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAutorCommandHandler> _logger;

        public CreateAutorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateAutorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(CreateAutorCommand request, CancellationToken cancellationToken)
        {
            await ExistRecordInDatabase(request);

            var libroIds = await _unitOfWork.LibroRepository.GetAsync(x => request.LibroId.Contains(x.Id));

            var autor = _mapper.Map<Domain.Autor>(request);

            autor.Libros = libroIds.ToList();

            _unitOfWork.AutorRepository.AddAsync(autor);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Autor `{request.Nombres}` creado.");
            return autor.Id;
        }

        private async Task ExistRecordInDatabase(CreateAutorCommand createAutorCommand)
        {
            var result = await _unitOfWork.AutorRepository
                .GetByAsync(x => (
                x.Nombres == createAutorCommand.Nombres &&
                x.Apellidos == createAutorCommand.Apellidos &&
                x.FechaNacimiento == createAutorCommand.FechaNacimiento &&
                x.Pseudonimo == createAutorCommand.Pseudonimo
                ));

            if (result != null)
            {
                _logger.LogError($"Autor `{createAutorCommand.Nombres}` no creado, ya existe uno con los mismos datos.");
                throw new BadRequestException($"El record no se pudo crear: {typeof(Domain.Autor).Name}");
            }
        }
    }
}
