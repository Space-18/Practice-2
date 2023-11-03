using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Categoria.Commands.DeleteCategoria
{
    public record DeleteCategoriaCommand : IRequest
    {
        public string Id { get; set; }
    }
}
