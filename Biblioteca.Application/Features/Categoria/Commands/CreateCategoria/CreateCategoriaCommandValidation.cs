using FluentValidation;

namespace Biblioteca.Application.Features.Categoria.Commands.CreateCategoria
{
    public class CreateCategoriaCommandValidation : AbstractValidator<CreateCategoriaCommand>
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
