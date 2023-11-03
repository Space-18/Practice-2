using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.DeleteCategoria
{
    internal class DeleteCategoriaCommandValidator : AbstractValidator<DeleteCategoriaCommand>
    {
        public DeleteCategoriaCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
