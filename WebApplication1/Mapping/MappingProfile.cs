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

            CreateMap<AuthorResource, Author>();
            CreateMap<GenreResource, Genre>();
            CreateMap<BookResource, Book>();

            CreateMap<SaveAuthorResource, Author>();
            CreateMap<SaveGenreResource, Genre>();
            CreateMap<SaveBookResource, Book>();
        }
    }
}
