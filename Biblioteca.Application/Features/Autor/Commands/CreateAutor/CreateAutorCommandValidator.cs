using FluentValidation;

namespace Biblioteca.Application.Features.Autor.Commands.CreateAutor
{
    public class CreateAutorCommandValidator : AbstractValidator<CreateAutorCommand>
    {
        public CreateAutorCommandValidator()
        {
            RuleFor(x => x.Nombres)
                .NotEmpty()
                .WithMessage("El campo {Nombres} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Nombres} no debe ser nulo.")
                .MinimumLength(1)
                .WithMessage("El campo {Nombres} debe tener 1 caracter como mínimo.")
                .MaximumLength(100)
                .WithMessage("El campo {Nombres} debe tener 50 caracteres como máximo.");

            RuleFor(x => x.Apellidos)
                .NotEmpty()
                .WithMessage("El campo {Apellidos} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Apellidos} no debe ser nulo.")
                .MinimumLength(1)
                .WithMessage("El campo {Apellidos} debe tener 1 caracter como mínimo.")
                .MaximumLength(100)
                .WithMessage("El campo {Apellidos} debe tener 50 caracteres como máximo.");

            RuleFor(x => x.Pseudonimo)
                .NotEmpty()
                .WithMessage("El campo {Pseudonimo} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Pseudonimo} no debe ser nulo.")
                .MinimumLength(1)
                .WithMessage("El campo {Pseudonimo} debe tener 1 caracter como mínimo.")
                .MaximumLength(100)
                .WithMessage("El campo {Pseudonimo} debe tener 50 caracteres como máximo.");

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty()
                .WithMessage("El campo {Fecha de Nacimiento} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Fecha de Nacimiento} no debe ser nulo.")
                .NotEqual(DateTime.MinValue)
                .WithMessage("El campo {Fecha de Nacimiento} no debe ser un valor mínimo.");
        }
    }
}
