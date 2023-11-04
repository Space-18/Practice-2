using FluentValidation;

namespace Biblioteca.Application.Features.Libro.Commands.DeleteLibro
{
    public class DeleteLibroCommandValidator : AbstractValidator<DeleteLibroCommand>
    {
        public DeleteLibroCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
