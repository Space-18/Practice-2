using FluentValidation;

namespace Biblioteca.Application.Features.Editorial.Commands.DeleteEditorial
{
    public class DeleteEditorialCommandValidator : AbstractValidator<DeleteEditorialCommand>
    {
        public DeleteEditorialCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
