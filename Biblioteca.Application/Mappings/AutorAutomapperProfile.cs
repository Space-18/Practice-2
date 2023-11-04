using AutoMapper;
using Biblioteca.Application.Features.Autor.Commands.CreateAutor;
using Biblioteca.Application.Features.Autor.Commands.UpdateAutor;
using Biblioteca.Application.Models.Request.Autor;
using Biblioteca.Application.Models.Response.Autor;
using Biblioteca.Application.Models.Response.Libro;
using Biblioteca.Domain;

namespace Biblioteca.Application.Mappings
{
    internal class AutorAutomapperProfile : Profile
    {
        public AutorAutomapperProfile()
        {
            CreateMap<Autor, AutorViewModel>();
            CreateMap<Autor, AutorLibrosViewModel>()
                .ForMember(x => x.Libros, y => y.MapFrom(MapLibrosToLibrosViewModel));
            CreateMap<CreateAutorDTO, CreateAutorCommand>();
            CreateMap<CreateAutorCommand, Autor>()
                .ForMember(x => x.Libros, y => y.Ignore());
            CreateMap<CreateAutorDTO, UpdateAutorCommand>();
            CreateMap<UpdateAutorCommand, Autor>()
                .ForMember(x => x.Libros, y => y.Ignore());
        }

        private List<LibrosViewModel> MapLibrosToLibrosViewModel(Autor autor, AutorLibrosViewModel autorViewModel)
        {
            var result = new List<LibrosViewModel>();

            if (autor.Libros == null)
                return result;

            foreach (var item in autor.Libros)
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
