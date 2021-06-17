using AutoMapper;
using Data.Dtos.AuthorDtos;
using Data.Model;

namespace Data.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            // Source -> Target
            CreateMap<Author, AuthorReadDto>();
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();
            CreateMap<Author, AuthorUpdateDto>();
        }

    }
}
