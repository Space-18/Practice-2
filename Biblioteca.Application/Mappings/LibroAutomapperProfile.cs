using AutoMapper;
using Biblioteca.Application.Features.Libro.Commands.CreateLibro;
using Biblioteca.Application.Features.Libro.Commands.UpdateLibro;
using Biblioteca.Application.Models.Request.Libro;
using Biblioteca.Application.Models.Response.Autor;
using Biblioteca.Application.Models.Response.Categoria;
using Biblioteca.Application.Models.Response.Editorial;
using Biblioteca.Application.Models.Response.Libro;
using Biblioteca.Domain;

namespace Biblioteca.Application.Mappings
{
    internal class LibroAutomapperProfile : Profile
    {
        public LibroAutomapperProfile()
        {
            CreateMap<Libro, LibrosViewModel>();

            CreateMap<Libro, LibroCategoriaAutorEditorialViewModel>()
                .ForMember(x => x.Categorias, y => y.MapFrom(MapCategoriaToCategoriaViewModel))
                .ForMember(x => x.Autors, y => y.MapFrom(MapAutorToAutorViewModel))
                .ForMember(x => x.Editorials, y => y.MapFrom(MapEditorialToEditorialViewModel));

            CreateMap<CreateLibroDTO, CreateLibroCommand>();

            CreateMap<CreateLibroCommand, Libro>()
                .ForMember(x => x.Categorias, y => y.Ignore())
                .ForMember(x => x.Autors, y => y.Ignore())
                .ForMember(x => x.Editorials, y => y.Ignore());
            //    .ForMember(x => x.Categorias, y => y.MapFrom(MapLibroCategorias))
            //    .ForMember(x => x.Autors, y => y.MapFrom(MapLibroAutors))
            //    .ForMember(x => x.Editorials, y => y.MapFrom(MapLibroEditorials);

            ////.ForMember(x => x.Categorias, y => y.MapFrom(z=> MapLibroCategorias(z.CategoriaId)))
            ////.ForMember(x => x.Autors, y => y.MapFrom(z=>MapLibroAutors(z.AutorId)))
            ////.ForMember(x => x.Editorials, y => y.MapFrom(z=>MapLibroEditorials(z.EditorialId)));

            ////CreateMap<string, LibroCategoria>()
            ////.ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src));
            ////CreateMap<List<string>, List<LibroCategoria>>()
            ////.ConvertUsing(src => src.Select(item => new LibroCategoria { CategoriaId = item }).ToList());

            ////CreateMap<string, LibroAutor>()
            ////    .ForMember(dest => dest.AutorId, opt => opt.MapFrom(src => src));
            ////CreateMap<List<string>, List<LibroAutor>>()
            ////.ConvertUsing(src => src.Select(item => new LibroAutor { AutorId = item }).ToList());

            ////CreateMap<string, LibroEditorial>()
            ////    .ForMember(dest => dest.EditorialId, opt => opt.MapFrom(src => src));
            ////CreateMap<List<string>, List<LibroEditorial>>()
            ////.ConvertUsing(src => src.Select(item => new LibroEditorial { EditorialId = item }).ToList());

            CreateMap<CreateLibroDTO, UpdateLibroCommand>();
            CreateMap<UpdateLibroCommand, Libro>()
                .ForMember(x => x.Categorias, y => y.Ignore())
                .ForMember(x => x.Autors, y => y.Ignore())
                .ForMember(x => x.Editorials, y => y.Ignore());
        }

        private List<CategoriaViewModel> MapCategoriaToCategoriaViewModel(Libro libro, LibroCategoriaAutorEditorialViewModel libroCategoriaAutorEditorialViewModel)
        {
            var result = new List<CategoriaViewModel>();

            if (libro.Categorias == null)
            {
                return result;
            }

            foreach (var item in libro.Categorias)
            {
                result.Add(
                    new CategoriaViewModel
                    {
                        Id = item.Id,
                        Nombre = item.Nombre
                    });
            }

            return result;
        }

        private List<AutorViewModel> MapAutorToAutorViewModel(Libro libro, LibroCategoriaAutorEditorialViewModel libroCategoriaAutorEditorialViewModel)
        {
            var result = new List<AutorViewModel>();

            if (libro.Categorias == null)
            {
                return result;
            }

            foreach (var item in libro.Autors)
            {
                result.Add(
                    new AutorViewModel
                    {
                        Id = item.Id,
                        Nombres = item.Nombres,
                        Apellidos = item.Apellidos
                    });
            }

            return result;
        }

        private List<EditorialViewModel> MapEditorialToEditorialViewModel(Libro libro, LibroCategoriaAutorEditorialViewModel libroCategoriaAutorEditorialViewModel)
        {
            var result = new List<EditorialViewModel>();

            if (libro.Categorias == null)
            {
                return result;
            }

            foreach (var item in libro.Editorials)
            {
                result.Add(
                    new EditorialViewModel
                    {
                        Id = item.Id,
                        Nombre = item.Nombre
                    });
            }

            return result;
        }

        //private List<LibroCategoria> MapLibroCategorias(CreateLibroCommand createLibroCommand, Libro libro)
        ////private List<LibroCategoria> MapLibroCategorias(List<string> categoriaIds)
        //{
        //    var result = new List<LibroCategoria>();

        //    if (createLibroCommand.CategoriaId == null)
        //    {
        //        return result;
        //    }

        //    foreach (var item in createLibroCommand.CategoriaId)
        //    {
        //        result.Add(new LibroCategoria()
        //        {
        //            CategoriaId = item
        //        });
        //    }

        //    return result;

        //    //if (categoriaIds == null)
        //    //{
        //    //    return new List<LibroCategoria>();
        //    //}

        //    //var result = categoriaIds.Select(categoriaId => new LibroCategoria { CategoriaId = categoriaId }).ToList();
        //    //return result;
        //}

        //private List<LibroAutor> MapLibroAutors(CreateLibroCommand createLibroCommand, Libro libro)
        ////private List<LibroAutor> MapLibroAutors(List<string> autorIds)
        //{
        //    var result = new List<LibroAutor>();

        //    if (createLibroCommand.AutorId == null)
        //    {
        //        return result;
        //    }

        //    foreach (var item in createLibroCommand.AutorId)
        //    {
        //        result.Add(new LibroAutor
        //        {
        //            AutorId = item
        //        });
        //    }

        //    return result;

        //    //if (autorIds == null)
        //    //{
        //    //    return new List<LibroAutor>();
        //    //}

        //    //var result = autorIds.Select(autorId => new LibroAutor { AutorId = autorId }).ToList();
        //    //return result;
        //}

        //private List<LibroEditorial> MapLibroEditorials(CreateLibroCommand createLibroCommand, Libro libro)
        ////private List<LibroEditorial> MapLibroEditorials(List<string> editorialIds)
        //{
        //    var result = new List<LibroEditorial>();

        //    if (createLibroCommand.EditorialId == null)
        //    {
        //        return result;
        //    }

        //    foreach (var item in createLibroCommand.EditorialId)
        //    {
        //        result.Add(new LibroEditorial
        //        {
        //            EditorialId = item
        //        });
        //    }

        //    return result;

        //    //if (editorialIds == null)
        //    //{
        //    //    return new List<LibroEditorial>();
        //    //}

        //    //var result = editorialIds.Select(editorialId => new LibroEditorial { EditorialId = editorialId }).ToList();
        //    //return result;
        //}
    }
}
