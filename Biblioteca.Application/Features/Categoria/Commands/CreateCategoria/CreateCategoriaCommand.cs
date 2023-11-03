using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.CreateCategoria
{
    public record CreateCategoriaCommand : IRequest<string>
    {
        public string Nombre { get; set; }
    }
}
