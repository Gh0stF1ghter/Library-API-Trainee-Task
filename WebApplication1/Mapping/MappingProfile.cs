using API.Resources;
using AutoMapper;
using Core.Models;

namespace API.Mappers
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
