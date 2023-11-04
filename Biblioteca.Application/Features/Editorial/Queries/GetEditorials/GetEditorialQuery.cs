using Biblioteca.Application.Models.Response.Editorial;
using MediatR;

namespace Biblioteca.Application.Features.Editorial.Queries.GetEditorials
{
    public record GetEditorialQuery : IRequest<List<EditorialViewModel>>
    {
    }
}
