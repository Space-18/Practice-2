﻿using FluentValidation;

namespace Biblioteca.Application.Features.Libro.Commands.UpdateLibro
{
    public class UpdateLibroCommandValidator : AbstractValidator<UpdateLibroCommand>
    {
        public UpdateLibroCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El campo {Id} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Id} no debe ser nulo.");

            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("El campo {Nombre} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Nombre} no debe ser nulo.")
                .MinimumLength(2)
                .WithMessage("El campo {Nombre} debe tener 2 caracteres como mínimo.")
                .MaximumLength(50)
                .WithMessage("El campo {Nombre} debe tener 50 caracteres como máximo.");

            RuleFor(x => x.ISBN)
                .NotEmpty()
                .WithMessage("El campo {ISBN} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {ISBN} no debe ser nulo.")
                .NotEqual(0)
                .WithMessage("El campo {ISBN} no puede ser 0.");

            RuleFor(x => x.FechaPublicacion)
                .NotEmpty()
                .WithMessage("El campo {Fecha de Publicación} no debe ser vacio.")
                .NotNull()
                .WithMessage("El campo {Fecha de Publicación} no debe ser nulo.")
                .NotEqual(DateTime.MinValue)
                .WithMessage("El campo {Fecha de Publicación} no debe ser un valor mínimo.");
        }
    }
}
