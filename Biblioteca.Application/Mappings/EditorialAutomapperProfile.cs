using AutoMapper;
using Biblioteca.Application.Features.Editorial.Commands.CreateEditorial;
using Biblioteca.Application.Features.Editorial.Commands.UpdateEditorial;
using Biblioteca.Application.Models.Request.Editorial;
using Biblioteca.Application.Models.Response.Editorial;
using Biblioteca.Application.Models.Response.Libro;
using Biblioteca.Domain;

namespace Biblioteca.Application.Mappings
{
    internal class EditorialAutomapperProfile : Profile
    {
        public EditorialAutomapperProfile()
        {
            CreateMap<Editorial, EditorialViewModel>();
            CreateMap<Editorial, EditorialLibrosViewModel>()
                .ForMember(x => x.Libros, y => y.MapFrom(MapLibrosToLibrosViewModel));
            CreateMap<CreateEditorialDTO, CreateEditorialCommand>();
            CreateMap<CreateEditorialCommand, Editorial>()
                .ForMember(x => x.Libros, y => y.Ignore());
            CreateMap<CreateEditorialDTO, UpdateEditorialCommand>();
            CreateMap<UpdateEditorialCommand, Editorial>()
                .ForMember(x => x.Libros, y => y.Ignore());
        }

        private List<LibrosViewModel> MapLibrosToLibrosViewModel(Editorial editorial, EditorialLibrosViewModel editorialViewModel)
        {
            var result = new List<LibrosViewModel>();

            if (editorial.Libros == null)
                return result;

            foreach (var item in editorial.Libros)
            {
                result.Add(
                    new LibrosViewModel
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        FechaPublicacion = item.FechaPublicacion,
                        Imagen = item.Imagen
                    });
            }

            return result;
        }
    }
}
