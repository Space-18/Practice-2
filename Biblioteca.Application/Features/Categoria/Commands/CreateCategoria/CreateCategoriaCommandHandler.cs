using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.CreateCategoria
{
    internal class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCategoriaCommandHandler> _logger;

        public CreateCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,ILogger<CreateCategoriaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            await ExistRecordInDatabase(request.Nombre);

            var categoria = _mapper.Map<Domain.Categoria>(request);

            _unitOfWork.CategoriaRepository.AddAsync(categoria);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Categoría `{request.Nombre}` creada.");
            return categoria.Id;
        }

        private async Task ExistRecordInDatabase(string nombre)
        {
            var result = await _unitOfWork.CategoriaRepository.GetByAsync(x => x.Nombre == nombre);

            if (result != null)
            {
                _logger.LogError($"Categoría `{nombre}` no creada, ya existe uno con el mismo nombre.");
                throw new BadRequestException("El record no se pudo crear.");
            }
        }
    }
}
