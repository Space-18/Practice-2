using FluentValidation;

namespace Biblioteca.Application.Features.Editorial.Commands.CreateEditorial
{
    public class CreateEditorialCommandValidator : AbstractValidator<CreateEditorialCommand>
    {
        public CreateEditorialCommandValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("El campo {Nombre} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Nombre} no debe ser nulo.")
                .MinimumLength(1)
                .WithMessage("El campo {Nombre} debe tener 1 caracter como mínimo.")
                .MaximumLength(50)
                .WithMessage("El campo {Nombre} debe tener 50 caracteres como máximo.");

            RuleFor(x => x.SitioWeb)
                .MinimumLength(3)
                .WithMessage("EL campo {Sitio web} debe tener como mínimo 3 caracteres.");
        }
    }
}
