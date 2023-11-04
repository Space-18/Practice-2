using Biblioteca.Application.Models.Response.Editorial;
using MediatR;

namespace Biblioteca.Application.Features.Editorial.Queries.GetEditorialById
{
    public record GetEditorialByIdQuery : IRequest<EditorialLibrosViewModel>
    {
        public string Id { get; set; }
    }
}
