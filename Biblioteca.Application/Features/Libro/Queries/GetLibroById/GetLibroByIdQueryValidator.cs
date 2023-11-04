using FluentValidation;

namespace Biblioteca.Application.Features.Libro.Queries.GetLibroById
{
    public class GetLibroByIdQueryValidator : AbstractValidator<GetLibroByIdQuery>
    {
        public GetLibroByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
