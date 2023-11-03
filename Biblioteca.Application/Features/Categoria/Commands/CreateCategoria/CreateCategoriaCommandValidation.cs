using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.CreateCategoria
{
    internal class CreateCategoriaCommandValidation : AbstractValidator<CreateCategoriaCommand>
    {
        public CreateCategoriaCommandValidation()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("El campo {Nombre} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Nombre} no debe ser nulo.")
                .MinimumLength(2)
                .WithMessage("El campo {Nombre} debe tener 2 caracteres como mínimo.")
                .MaximumLength(50)
                .WithMessage("El campo {Nombre} debe tener 50 caracteres como máximo.");
        }
    }
}
