using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.UpdateCategoria
{
    public record UpdateCategoriaCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}
