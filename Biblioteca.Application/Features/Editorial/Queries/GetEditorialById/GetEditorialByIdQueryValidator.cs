using FluentValidation;

namespace Biblioteca.Application.Features.Editorial.Queries.GetEditorialById
{
    public class GetEditorialByIdQueryValidator : AbstractValidator<GetEditorialByIdQuery>
    {
        public GetEditorialByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
