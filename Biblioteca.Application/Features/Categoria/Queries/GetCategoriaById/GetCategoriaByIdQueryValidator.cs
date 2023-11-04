using FluentValidation;

namespace Biblioteca.Application.Features.Categoria.Queries.GetCategoriaById
{
    public class GetCategoriaByIdQueryValidator : AbstractValidator<GetCategoriaByIdQuery>
    {
        public GetCategoriaByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");
        }
    }
}
