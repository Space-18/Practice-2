﻿using MediatR;

namespace Biblioteca.Application.Features.Autor.Commands.CreateAutor
{
    public record CreateAutorCommand : IRequest<string>
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Pseudonimo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<string> LibroId { get; set; }
    }
}
