using FluentValidation;

namespace Biblioteca.Application.Features.Categoria.Commands.DeleteCategoria
{
    public class DeleteCategoriaCommandValidator : AbstractValidator<DeleteCategoriaCommand>
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
