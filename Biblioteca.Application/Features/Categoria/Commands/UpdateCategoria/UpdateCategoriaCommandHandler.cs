using AutoMapper;
using Biblioteca.Application.Contracts.Persistence;
using Biblioteca.Application.Exceptions;
using Biblioteca.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.UpdateCategoria
{
    internal class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoriaCommandHandler> _logger;

        public UpdateCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,ILogger<UpdateCategoriaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await ExistRecordInDatabase(request.Id);

            _mapper.Map(request, categoria);

            _unitOfWork.CategoriaRepository.UpdateAsync(categoria);

            await _unitOfWork.Complete();

            _logger.LogInformation($"Categoria {categoria.Id} modificada.");
            return categoria.Id;
        }

        private async Task<Domain.Categoria> ExistRecordInDatabase(string id)
        {
            var result = await _unitOfWork.CategoriaRepository.GetByIdAsync(id);

            if(result == null)
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
