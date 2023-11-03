using Biblioteca.Application.Models.Response.Libro;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Features.Libro.Queries.GetLibros
{
    public class GetLibrosQuery : IRequest<List<LibrosViewModel>>
    {
    }
}
