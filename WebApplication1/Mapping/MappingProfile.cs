using AutoMapper;
using Core.Models;
using Core.Resources;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorResource>();
            CreateMap<Genre, GenreResource>();
            CreateMap<Book, BookResource>();
            CreateMap<BookGenre, BookGenreResource>();

            CreateMap<AuthorResource, Author>();
            CreateMap<GenreResource, Genre>();
            CreateMap<BookResource, Book>();
            CreateMap<BookGenreResource, BookGenre>();


            CreateMap<SaveAuthorResource, Author>();
            CreateMap<SaveGenreResource, Genre>();
            CreateMap<SaveBookResource, Book>();
        }
    }
}
