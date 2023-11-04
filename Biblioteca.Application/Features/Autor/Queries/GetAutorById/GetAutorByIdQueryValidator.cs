using FluentValidation;

namespace Biblioteca.Application.Features.Autor.Queries.GetAutorById
{
    public class GetAutorByIdQueryValidator : AbstractValidator<GetAutorByIdQuery>
    {
        public GetAutorByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
