using FluentValidation;

namespace Biblioteca.Application.Features.Autor.Commands.DeleteAutor
{
    public class DeleteAutorCommandValidator : AbstractValidator<DeleteAutorCommand>
    {
        public DeleteAutorCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
