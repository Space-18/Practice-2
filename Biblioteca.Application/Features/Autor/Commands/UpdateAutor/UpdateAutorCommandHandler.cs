using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Features.Autor.Commands.UpdateAutor
{
    internal class UpdateAutorCommandHandler : IRequestHandler<UpdateAutorCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAutorCommandHandler> _logger;

        public UpdateAutorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateAutorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = await ExistRecordInDatabase(request.Id);
            var libroIds = await _unitOfWork.LibroRepository.GetAsync(x => request.LibroId.Contains(x.Id));

            _mapper.Map(request, autor);

            autor.Libros = libroIds.ToList();

            _unitOfWork.AutorRepository.UpdateAsync(autor);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Autor {autor.Id} modificado.");
            return autor.Id;
        }

        private async Task<Domain.Autor> ExistRecordInDatabase(string id)
        {
            var autor = await _unitOfWork.AutorRepository.GetAutorWithLibros(id);

            if (autor == null)
            {
                _logger.LogError($"Autor {id} no modificado, no se encontró el recurso.");
                throw new NotFoundException(typeof(Domain.Autor).Name, id);
            }
            else
            {
                return autor;
            }
        }
    }
}
