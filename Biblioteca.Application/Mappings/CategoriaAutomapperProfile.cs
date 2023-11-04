using AutoMapper;
using Biblioteca.Application.Features.Categoria.Commands.CreateCategoria;
using Biblioteca.Application.Features.Categoria.Commands.UpdateCategoria;
using Biblioteca.Application.Models.Request.Categoria;
using Biblioteca.Application.Models.Response.Categoria;
using Biblioteca.Application.Models.Response.Libro;
using Biblioteca.Domain;

namespace Biblioteca.Application.Mappings
{
    internal class CategoriaAutomapperProfile : Profile
    {
        public CategoriaAutomapperProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();

            CreateMap<Categoria, CategoriaLibrosViewModel>()
                .ForMember(x => x.Libros, y => y.MapFrom(MapLibrosToLibroViewModel));

            CreateMap<CreateCategoriaDTO, CreateCategoriaCommand>();

            CreateMap<CreateCategoriaCommand, Categoria>();

            CreateMap<UpdateCategoriaCommand, Categoria>();
        }

        private List<LibrosViewModel> MapLibrosToLibroViewModel(Categoria categoria, CategoriaLibrosViewModel categoriaLibrosViewModel)
        {
            var result = new List<LibrosViewModel>();

            if (categoria.Libros == null)
            {
                return result;
            }

            foreach (var item in categoria.Libros)
            {
                result.Add(
                    new LibrosViewModel
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        //ISBN = item.ISBN,
                        FechaPublicacion = item.FechaPublicacion,
                        Imagen = item.Imagen
                    });
            }

            return result;
        }
    }
}
